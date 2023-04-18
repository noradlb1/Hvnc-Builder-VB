Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace HVNC
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		''' <summary>
		''' Point d'entrée principal de l'application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Dim myType = GetType(Program)

			Dim resource2 As String = myType.Namespace & ".DLL.Mono.Cecil.dll"

			EmbeddedAssembly.Load(resource2, "Mono.Cecil.dll")

			AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New FrmMain())
		End Sub

		Private Shared Function CurrentDomain_AssemblyResolve(ByVal sender As Object, ByVal args As ResolveEventArgs) As System.Reflection.Assembly
			Return EmbeddedAssembly.Get(args.Name)
		End Function
	End Class
End Namespace
