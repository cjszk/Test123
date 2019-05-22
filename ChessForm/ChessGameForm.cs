using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class ChessForm : Form
    {
        Game newGame = new Game();
        // class member array of Panels to track chessboard tiles
        const int tileSize = 70;
        const int gridSize = 9;
        public static int turn = 0;
        private ChessPanel[,] chessBoardPanels = new ChessPanel[gridSize, gridSize];
        ChessPanel selectedPanel;
        Board board = new Board();
        int[,] validMoves;

        public ChessForm()
        {
            InitializeComponent();
        }

        // event handler of Form Load... init things here
        private void ChessForm_Load(object sender, EventArgs e) {}

        private Label CreateLabel(string text)
        {
            Label label = new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Top = 20,
            };
            return label;
        }

        private void UpdateUI()
        {
            for (int column = 0; column < gridSize; column++)
            {
                for (int row = 0; row < gridSize; row++)
                {
                    ChessPanel panel = chessBoardPanels[row, column];
                    panel.BackColor = panel.baseColor;
                    CheckTileForPiece(row, column, panel);
                }
            }
            selectedPanel = null;
        }

        private bool CheckTileForPiece(int row, int column, ChessPanel panel)
        {
            // TODO Implement code to check the 2D array to see if a piece exists, then insert the piece.
            int pieceNumber = board.ShowBoardState()[row, column];
            
            string gamePiece = GetGamePieceByNumber(pieceNumber);
            if (gamePiece != "None")
            {
                InsertGamePiece(panel, gamePiece);
                return true;
            }
            RemoveGamePiece(panel);
            return false;
        }

        public string GetGamePieceByNumber(int number)
        {
            string[] dummyGamePieceList = 
            {
                "None",
                "WhitePawn.png", "WhiteRook.png", "WhiteKnight.png", "WhiteBishop.png", "WhiteKing.png", "WhiteQueen.png",
                "BlackPawn.png", "BlackRook.png", "BlackKnight.png", "BlackBishop.png", "BlackKing.png", "BlackQueen.png"
            };
            return dummyGamePieceList[number];
        }

        private void InsertGamePiece(ChessPanel panel, string gamePiece)
        {
            // Ensure that the directory matches on your local computer
            string imageFileDirectory = $@"{Directory.GetCurrentDirectory()}\Images\{gamePiece}";
            panel.BackgroundImage = Image.FromFile(imageFileDirectory);
            panel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void RemoveGamePiece(ChessPanel panel)
        {
            panel.BackgroundImage = null;
        }

        void HighlightValidMoves(int panelRow, int panelColumn)
        {
            validMoves = board.GetPieceMoves(panelRow, panelColumn);
            // TODO: Stop pieces from being able to jump (except knight)
            // Disable highlighting until this is fixed.

            for (int column = 0; column < gridSize; column++)
            {
                for (int row = 0; row < gridSize; row++)
                {
                    ChessPanel panel = chessBoardPanels[row, column];
                    if (validMoves[row, column] == -1)
                    {
                        panel.BackColor = Color.Blue;
                    }
                    else if (validMoves[row, column] == -2)
                    {
                        panel.BackColor = Color.Red;
                    }
                    else panel.BackColor = panel.baseColor;
                }
            }
        }

        private void SelectPiece(ChessPanel panel)
        {
            // int pieceNumber = board.ShowBoardState()[panel.row, panel.column];
            if (selectedPanel != null && selectedPanel.baseColor != null) selectedPanel.BackColor = selectedPanel.baseColor;
            selectedPanel = panel;
            selectedPanel.BackColor = Color.Green;
            HighlightValidMoves(panel.row, panel.column);
        }
        
        void HandleClick(object sender, EventArgs e, ChessPanel panel)
        {
            int row = panel.row;
            int column = panel.column;
            int[,] boardState = board.ShowBoardState();
            // White Turn
            if (turn % 2 == 0)
            {
                if (boardState[row, column] > 0 && boardState[row, column] < 7) SelectPiece(panel);
                else if (validMoves != null && validMoves[row, column] < 0 && selectedPanel != null)
                {
                    board.movePiece(selectedPanel.row, selectedPanel.column, panel);
                    turn++;
                    UpdateUI();
                }
            }
            // Black Turn
            else
            {
                if (boardState[row, column] > 6) SelectPiece(panel);
                else if (validMoves != null && validMoves[row, column] < 0 && selectedPanel != null)
                {
                    board.movePiece(selectedPanel.row, selectedPanel.column, panel);
                    turn++;
                    UpdateUI();
                }
            }
        }

        private void CreatePanel(ChessPanel panel, int row, int column)
        {
            if (column % 2 == 0) panel.baseColor = row % 2 != 0 ? Color.DarkGray : Color.White;
            else panel.baseColor = row % 2 == 0 ? Color.DarkGray : Color.White;
            panel.BackColor = panel.baseColor;
            panel.MouseClick +=  ((o, a) => HandleClick(o, a, panel));
            CheckTileForPiece(row, column, panel);
        }

        private void StartGame()
        {
            // double for loop to handle all rows and columns
            for (int column = 0; column < gridSize; column++)
            {
                for (int row = 0; row < gridSize; row++)
                {
                    // create new Panel control which will be one chess board tile
                    var newPanel = new ChessPanel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * column, tileSize * row),
                    };
                    // add to Form's Controls so that they show up
                    Controls.Add(newPanel);
                    // add to our 2d array of panels for future use
                    chessBoardPanels[row, column] = newPanel;

                    // create the positional grid labels
                    if (column == 0 && row == 8) continue;
                    
                    // label the row and column of the panel for reference purposes
                    newPanel.row = row;
                    newPanel.column = column;
                    if (column > 0 && row == 8)
                    {
                        // A => H Grid
                        Label label = CreateLabel(((char)(column + 64)).ToString());
                        newPanel.Controls.Add(label);
                    }
                    else if (column == 0 && row < 8)
                    {
                        // 1 => 8 Grid
                        Label label = CreateLabel(((row - 8) * -1).ToString());
                        newPanel.Controls.Add(label);
                    }
                    // color the backgrounds && add fillers (chess pieces to be displayed)
                    else if (column % 2 == 0)
                    {
                        // TODO: Any chess pieces in this tile? add it.
                        CreatePanel(newPanel, row, column);
                    }
                    else
                    {
                        CreatePanel(newPanel, row, column);
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: Undo the last move");
            //UpdateUI();
        }

        private void ClearForm()
        {
            label1.Dispose();
            label2.Dispose();
            maskedTextBox1.Dispose();
            maskedTextBox2.Dispose();
            button2.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // TODO Create Player Classes out of maskedTextBox1.Text && maskedTextBox2.Text
            if (maskedTextBox1.Text.Length == 0 || maskedTextBox2.Text.Length == 0) MessageBox.Show("Player names are required, please type your names.");
            else
            {
                MessageBox.Show($"Starting Game: \nWhite Player: {maskedTextBox1.Text} \nBlack Player: {maskedTextBox2.Text}");
                newGame.Players[0].SetUsername(maskedTextBox1.Text);
                newGame.Players[1].SetUsername(maskedTextBox2.Text);
                label3.Text = "White Player: ";
                label4.Text = maskedTextBox1.Text;
                label6.Text = "Black Player: ";
                label5.Text = maskedTextBox2.Text;
                ClearForm();
                StartGame();
            }
        }
    }
}