Imports System
Imports System.Collections
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

	Friend Class AeroListView
		Inherits ListView

		Private Const WM_CHANGEUISTATE As UInteger = &H127

		Private Const UIS_SET As Short = 1
		Private Const UISF_HIDEFOCUS As Short = &H1
		Private ReadOnly _removeDots As New IntPtr(NativeMethodsHelper.MakeWin32Long(UIS_SET, UISF_HIDEFOCUS))

		Private Property LvwColumnSorter() As ListViewColumnSorter

		''' <summary>
		''' Initializes a new instance of the <see cref="AeroListView"/> class.
		''' </summary>
		Public Sub New()
			SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
			Me.LvwColumnSorter = New ListViewColumnSorter()
			Me.ListViewItemSorter = LvwColumnSorter
			Me.View = View.Details
			Me.FullRowSelect = True
		End Sub

		''' <summary>
		''' Raises the <see cref="E:HandleCreated" /> event.
		''' </summary>
		''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
			MyBase.OnHandleCreated(e)

			If PlatformHelper.RunningOnMono Then
				Return
			End If

			If PlatformHelper.VistaOrHigher Then
				' set window theme to explorer
				NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)
			End If

			If PlatformHelper.XpOrHigher Then
				' removes the ugly dotted line around focused item
				NativeMethods.SendMessage(Me.Handle, WM_CHANGEUISTATE, _removeDots, IntPtr.Zero)
			End If
		End Sub

		''' <summary>
		''' Raises the <see cref="E:ColumnClick" /> event.
		''' </summary>
		''' <param name="e">The <see cref="ColumnClickEventArgs"/> instance containing the event data.</param>
		Protected Overrides Sub OnColumnClick(ByVal e As ColumnClickEventArgs)
			MyBase.OnColumnClick(e)

			' Determine if clicked column is already the column that is being sorted.
			If e.Column = Me.LvwColumnSorter.SortColumn Then
				' Reverse the current sort direction for this column.
				Me.LvwColumnSorter.Order = If(Me.LvwColumnSorter.Order = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
			Else
				' Set the column number that is to be sorted; default to ascending.
				Me.LvwColumnSorter.SortColumn = e.Column
				Me.LvwColumnSorter.Order = SortOrder.Ascending
			End If

			' Perform the sort with these new sort options.
			If Not Me.VirtualMode Then
				Me.Sort()
			End If
		End Sub
	End Class

	Public Class ListViewColumnSorter
		Implements IComparer

		''' <summary>
		''' Specifies the column to be sorted
		''' </summary>
		Private _columnToSort As Integer

		''' <summary>
		''' Specifies the order in which to sort (i.e. 'Ascending').
		''' </summary>
		Private _orderOfSort As SortOrder

		''' <summary>
		''' Case insensitive comparer object
		''' </summary>
		Private ReadOnly _objectCompare As CaseInsensitiveComparer

		''' <summary>
		''' Class constructor.  Initializes various elements
		''' </summary>
		Public Sub New()
			' Initialize the column to '0'
			_columnToSort = 0

			' Initialize the sort order to 'none'
			_orderOfSort = SortOrder.None

			' Initialize the CaseInsensitiveComparer object
			_objectCompare = New CaseInsensitiveComparer()
		End Sub

		''' <summary>
		''' This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
		''' </summary>
		''' <param name="x">First object to be compared</param>
		''' <param name="y">Second object to be compared</param>
		''' <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
		Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
			' Cast the objects to be compared to ListViewItem objects
			Dim listviewX = DirectCast(x, ListViewItem)
			Dim listviewY = DirectCast(y, ListViewItem)

			If listviewX.SubItems(0).Text = ".." OrElse listviewY.SubItems(0).Text = ".." Then
				Return 0
			End If

			' Compare the two items
			Dim compareResult = _objectCompare.Compare(listviewX.SubItems(_columnToSort).Text, listviewY.SubItems(_columnToSort).Text)

			' Calculate correct return value based on object comparison
			If _orderOfSort = SortOrder.Ascending Then
				' Ascending sort is selected, return normal result of compare operation
				Return compareResult
			ElseIf _orderOfSort = SortOrder.Descending Then
				' Descending sort is selected, return negative result of compare operation
				Return (-compareResult)
			Else
				' Return '0' to indicate they are equal
				Return 0
			End If
		End Function

		''' <summary>
		''' Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
		''' </summary>
		Public Property SortColumn() As Integer
			Set(ByVal value As Integer)
				_columnToSort = value
			End Set
			Get
				Return _columnToSort
			End Get
		End Property

		''' <summary>
		''' Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
		''' </summary>
		Public Property Order() As SortOrder
			Set(ByVal value As SortOrder)
				_orderOfSort = value
			End Set
			Get
				Return _orderOfSort
			End Get
		End Property
	End Class

	Public NotInheritable Class NativeMethodsHelper

		Private Sub New()
		End Sub

		Private Const LVM_FIRST As Integer = &H1000
		Private Const LVM_SETITEMSTATE As Integer = LVM_FIRST + 43

		Private Const WM_VSCROLL As Integer = 277
		Private Shared ReadOnly SB_PAGEBOTTOM As New IntPtr(7)

		Public Shared Function MakeWin32Long(ByVal wLow As Short, ByVal wHigh As Short) As Integer
			Return CInt(wLow) << 16 Or CInt(CShort(wHigh))
		End Function

		Public Shared Sub SetItemState(ByVal handle As IntPtr, ByVal itemIndex As Integer, ByVal mask As Integer, ByVal value As Integer)
			Dim lvItem As NativeMethods.LVITEM = New NativeMethods.LVITEM With {.stateMask = mask, .state = value}

			NativeMethods.SendMessageListViewItem(handle, LVM_SETITEMSTATE, New IntPtr(itemIndex), lvItem)
		End Sub

		Public Shared Sub ScrollToBottom(ByVal handle As IntPtr)
			NativeMethods.SendMessage(handle, WM_VSCROLL, SB_PAGEBOTTOM, IntPtr.Zero)
		End Sub
	End Class

	''' <summary>
	''' Provides access to Win32 API and Microsoft C Runtime Library (msvcrt.dll).
	''' </summary>
	Public NotInheritable Class NativeMethods
		<StructLayout(LayoutKind.Sequential, CharSet := CharSet.Auto)> _
		Friend Structure LVITEM
			Public mask As UInteger
			Public iItem As Integer
			Public iSubItem As Integer
			Public state As Integer
			Public stateMask As Integer
			<MarshalAs(UnmanagedType.LPTStr)> _
			Public pszText As String
			Public cchTextMax As Integer
			Public iImage As Integer
			Public lParam As IntPtr
			Public iIndent As Integer
			Public iGroupId As Integer
			Public cColumns As UInteger
			Public puColumns As IntPtr
			Public piColFmt As IntPtr
			Public iGroup As Integer
		End Structure

		Private Sub New()
		End Sub


		<DllImport("user32.dll", CharSet := CharSet.Auto)> _
		Friend Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
		End Function

		<DllImport("user32.dll", CharSet := CharSet.Auto, EntryPoint := "SendMessage")> _
		Friend Shared Function SendMessageListViewItem(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As IntPtr, ByRef lParam As LVITEM) As IntPtr
		End Function

		<DllImport("user32.dll")> _
		Friend Shared Function RegisterHotKey(ByVal hWnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As UInteger, ByVal vk As Integer) As Boolean
		End Function

		<DllImport("user32.dll")> _
		Friend Shared Function UnregisterHotKey(ByVal hWnd As IntPtr, ByVal id As Integer) As Boolean
		End Function

		<DllImport("uxtheme.dll", CharSet := CharSet.Unicode)> _
		Friend Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal pszSubAppName As String, ByVal pszSubIdList As String) As Integer
		End Function
	End Class

	Public NotInheritable Class PlatformHelper

		Private Sub New()
		End Sub

		''' <summary>
		''' Initializes the <see cref="PlatformHelper"/> class.
		''' </summary>
		Shared Sub New()
			Win32NT = Environment.OSVersion.Platform = PlatformID.Win32NT
			XpOrHigher = Win32NT AndAlso Environment.OSVersion.Version.Major >= 5
			VistaOrHigher = Win32NT AndAlso Environment.OSVersion.Version.Major >= 6
			SevenOrHigher = Win32NT AndAlso (Environment.OSVersion.Version >= New Version(6, 1))
			EightOrHigher = Win32NT AndAlso (Environment.OSVersion.Version >= New Version(6, 2, 9200))
			EightPointOneOrHigher = Win32NT AndAlso (Environment.OSVersion.Version >= New Version(6, 3))
			TenOrHigher = Win32NT AndAlso (Environment.OSVersion.Version >= New Version(10, 0))
			RunningOnMono = Type.GetType("Mono.Runtime") IsNot Nothing

			Name = "Unknown OS"
			Using searcher = New ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")
				For Each os As ManagementObject In searcher.Get()
					Name = os("Caption").ToString()
					Exit For
				Next os
			End Using

			Name = Regex.Replace(Name, "^.*(?=Windows)", "").TrimEnd().TrimStart() ' Remove everything before first match "Windows" and trim end & start
			Is64Bit = Environment.Is64BitOperatingSystem
			FullName = $"{Name} {(Is64Bit ? 64 : 32)} Bit"
		End Sub

		''' <summary>
		''' Gets the full name of the operating system running on this computer (including the edition and architecture).
		''' </summary>
		Public Shared ReadOnly Property FullName() As String

		''' <summary>
		''' Gets the name of the operating system running on this computer (including the edition).
		''' </summary>
		Public Shared ReadOnly Property Name() As String

		''' <summary>
		''' Determines whether the Operating System is 32 or 64-bit.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is 64-bit, otherwise <c>false</c> for 32-bit.
		''' </value>
		Public Shared ReadOnly Property Is64Bit() As Boolean

		''' <summary>
		''' Returns a indicating whether the application is running in Mono runtime.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the application is running in Mono runtime; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property RunningOnMono() As Boolean

		''' <summary>
		''' Returns a indicating whether the Operating System is Windows 32 NT based.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is Windows 32 NT based; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property Win32NT() As Boolean

		''' <summary>
		''' Returns a value indicating whether the Operating System is Windows XP or higher.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is Windows XP or higher; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property XpOrHigher() As Boolean

		''' <summary>
		''' Returns a value indicating whether the Operating System is Windows Vista or higher.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is Windows Vista or higher; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property VistaOrHigher() As Boolean

		''' <summary>
		''' Returns a value indicating whether the Operating System is Windows 7 or higher.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is Windows 7 or higher; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property SevenOrHigher() As Boolean

		''' <summary>
		''' Returns a value indicating whether the Operating System is Windows 8 or higher.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is Windows 8 or higher; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property EightOrHigher() As Boolean

		''' <summary>
		''' Returns a value indicating whether the Operating System is Windows 8.1 or higher.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is Windows 8.1 or higher; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property EightPointOneOrHigher() As Boolean

		''' <summary>
		''' Returns a value indicating whether the Operating System is Windows 10 or higher.
		''' </summary>
		''' <value>
		'''   <c>true</c> if the Operating System is Windows 10 or higher; otherwise, <c>false</c>.
		''' </value>
		Public Shared ReadOnly Property TenOrHigher() As Boolean
	End Class