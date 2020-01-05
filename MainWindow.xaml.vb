Imports System.Runtime.InteropServices.Marshal
Imports OxyPlot

Class MainWindow

    Private m_nHistgram(255) As Integer

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    ''' <summary>
    ''' ファイル選択ボタンのクリックイベント
    ''' </summary>
    ''' <param name="sender">オブジェクト</param>
    ''' <param name="e">ルーティングイベントのデータ</param>
    Private Sub OnClickBtnFileSelect(sender As Object, e As RoutedEventArgs)
        Dim openFileDlg As ComOpenFileDialog = New ComOpenFileDialog()
        openFileDlg.Filter = "JPG|*.jpg|PNG|*.png"
        openFileDlg.Title = "Open the file"
        If (openFileDlg.ShowDialog() = True) Then
            image.Source = Nothing

            Dim bitmap As BitmapImage = New BitmapImage()
            bitmap.BeginInit()
            bitmap.UriSource = New Uri(openFileDlg.FileName)
            bitmap.EndInit()
            bitmap.Freeze()

            image.Source = bitmap

            DrawHistgram(bitmap)
        End If
        Return
    End Sub

    ''' <summary>
    ''' グラフ描画
    ''' </summary>
    Public Sub DrawHistgram(_bitmap As BitmapImage)
        InitHistgram()

        CalHistgram(_bitmap)

        Dim dataList = New List(Of DataPoint)()
        For nIdx As Integer = 0 To m_nHistgram.Length - 1
            Dim dataPoint = New DataPoint(nIdx, m_nHistgram(nIdx))
            dataList.Add(dataPoint)
        Next nIdx
        chart.ItemsSource = dataList
    End Sub

    ''' <summary>
    ''' イメージからヒストグラム用のデータ算出
    ''' </summary>
    Public Sub CalHistgram(_bitmap As BitmapImage)
        Dim nWidthSize As Integer = _bitmap.Width
        Dim nHeightSize As Integer = _bitmap.Height

        Dim wBitmap = New WriteableBitmap(_bitmap)

        Dim nIdxWidth As Integer
        Dim nIdxHeight As Integer

        For nIdxHeight = 0 To nHeightSize - 1 Step 1
            For nIdxWidth = 0 To nWidthSize - 1 Step 1
                Dim pAdr As IntPtr = wBitmap.BackBuffer
                Dim nPos As Integer = nIdxHeight * wBitmap.BackBufferStride + nIdxWidth * 4

                Dim nPixelB As Integer = ReadByte(pAdr, nPos + ComInfo.Pixel.B)
                Dim nPixelG As Integer = ReadByte(pAdr, nPos + ComInfo.Pixel.G)
                Dim nPixelR As Integer = ReadByte(pAdr, nPos + ComInfo.Pixel.R)

                Dim nGrayScale As Integer = (nPixelB + nPixelG + nPixelR) / 3

                m_nHistgram(nGrayScale) += 1
            Next
        Next
    End Sub

    ''' <summary>
    ''' ヒストグラム用のデータ初期化
    ''' </summary>
    Public Sub InitHistgram()
        For nIdx As Integer = 0 To m_nHistgram.Length - 1
            m_nHistgram(nIdx) = 0
        Next
    End Sub
End Class
