namespace Gomoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private PieceType nextPieceType = PieceType.BLACK;
        

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = Game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                Controls.Add(piece);

                if (Game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("Black Won!");
                }
                else if (Game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("White Won!");
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            this.Cursor = Game.CanBePlaced(e.X, e.Y) ? Cursors.Hand : Cursors.Default;



        }

        
    }
}
