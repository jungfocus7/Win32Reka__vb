Imports System



Public Interface HiInitializer
    Sub InitOnce(cbf As Action(Of String, Object))
End Interface
