Imports Microsoft.Win32

''' <summary>
''' ファイルオープンのロジック
''' </summary>
Public Class ComOpenFileDialog
    Protected m_openFileDialog As OpenFileDialog

    ''' <summary>
    ''' ファイル名称
    ''' </summary>
    Public Property FileName() As String
        Set(value As String)
            m_openFileDialog.FileName = value
        End Set
        Get
            Return m_openFileDialog.FileName
        End Get
    End Property

    ''' <summary>
    ''' ファイルダイアログに表示される初期ディレクトリ
    ''' </summary>
    Public Property InitialDirectory() As String
        Set(value As String)
            m_openFileDialog.InitialDirectory = value
        End Set
        Get
            Return m_openFileDialog.InitialDirectory
        End Get
    End Property

    ''' <summary>
    ''' ファイルの種類のフィルタ
    ''' </summary>
    Public Property Filter() As String
        Set(value As String)
            m_openFileDialog.Filter = value
        End Set
        Get
            Return m_openFileDialog.Filter
        End Get
    End Property

    ''' <summary>
    ''' 現在選択中のフィルタのインデックス
    ''' </summary>
    Public Property FilterIndex() As Integer
        Set(value As Integer)
            m_openFileDialog.FilterIndex = value
        End Set
        Get
            Return m_openFileDialog.FilterIndex
        End Get
    End Property

    ''' <summary>
    ''' ファイルダイアログに表示されるタイトル
    ''' </summary>
    Public Property Title() As String
        Set(value As String)
            m_openFileDialog.Title = value
        End Set
        Get
            Return m_openFileDialog.Title
        End Get
    End Property

    ''' <summary>
    ''' 存在しないファイルを指定した場合に警告を表示するかどうかの値
    ''' </summary>
    Public Property CheckFileExists() As Boolean
        Set(value As Boolean)
            m_openFileDialog.CheckFileExists = value
        End Set
        Get
            Return m_openFileDialog.CheckFileExists
        End Get
    End Property

    ''' <summary>
    ''' 無効なパスとファイルを入力した場合に警告を表示するかどうかの値
    ''' </summary>
    Public Property CheckPathExists() As Boolean
        Set(value As Boolean)
            m_openFileDialog.CheckPathExists = value
        End Set
        Get
            Return m_openFileDialog.CheckPathExists
        End Get
    End Property

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Public Sub New()
        m_openFileDialog = New OpenFileDialog()
    End Sub

    ''' <summary>
    ''' デスクトラクタ
    ''' </summary>
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' ダイアログの表示
    ''' </summary>
    ''' <returns>結果 成功/失敗</returns>
    Public Function ShowDialog() As Boolean
        Dim bRst As Boolean = False

        If (m_openFileDialog.ShowDialog() = True) Then
            bRst = True
        End If

        Return bRst
    End Function
End Class