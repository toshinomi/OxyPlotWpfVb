Imports Microsoft.Win32

Public Class ComOpenFileDialog
    Protected m_openFileDialog As OpenFileDialog

    Public Property FileName() As String
        Set(value As String)
            m_openFileDialog.FileName = value
        End Set
        Get
            Return m_openFileDialog.FileName
        End Get
    End Property

    Public Property InitialDirectory() As String
        Set(value As String)
            m_openFileDialog.InitialDirectory = value
        End Set
        Get
            Return m_openFileDialog.InitialDirectory
        End Get
    End Property

    Public Property Filter() As String
        Set(value As String)
            m_openFileDialog.Filter = value
        End Set
        Get
            Return m_openFileDialog.Filter
        End Get
    End Property

    Public Property FilterIndex() As Integer
        Set(value As Integer)
            m_openFileDialog.FilterIndex = value
        End Set
        Get
            Return m_openFileDialog.FilterIndex
        End Get
    End Property

    Public Property Title() As String
        Set(value As String)
            m_openFileDialog.Title = value
        End Set
        Get
            Return m_openFileDialog.Title
        End Get
    End Property

    Public Property CheckFileExists() As Boolean
        Set(value As Boolean)
            m_openFileDialog.CheckFileExists = value
        End Set
        Get
            Return m_openFileDialog.CheckFileExists
        End Get
    End Property

    Public Property CheckPathExists() As Boolean
        Set(value As Boolean)
            m_openFileDialog.CheckPathExists = value
        End Set
        Get
            Return m_openFileDialog.CheckPathExists
        End Get
    End Property

    Public Sub New()
        m_openFileDialog = New OpenFileDialog()
    End Sub

    Protected Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function ShowDialog() As Boolean
        Dim bRst As Boolean = False

        If (m_openFileDialog.ShowDialog() = True) Then
            bRst = True
        End If

        Return bRst
    End Function
End Class
