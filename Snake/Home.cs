using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging; // add this for the JPG compressor

namespace Snake
{

    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
            new Settings();
        }
        List<Circles> Snake = new List<Circles>(); //Tạo list chứa các Circles
        private Circles food = new Circles(); //Tạo biến food
        int maxWidth; //Chiều rộng tối đa của map
        int maxHeight; //Chiều dài tối đa của map
        int score; //Điểm
        int highScore; //Điểm kỉ lục
        Random rand = new Random();
        bool goLeft, goRight, goDown, goUp; //các biến bool mũi tên
        Rectangle rec = new Rectangle(12 * 16, 14 * 16, 64, 64); //tạo thử 1 chướng ngại hình vuông
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void KeyIsDown(object sender, KeyEventArgs e) //Nhấn xuống
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e) //Nhả ra
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }
        private void GameTimerEvent(object sender, EventArgs e)
        {

            if (goLeft)
            {
                Settings.directions = "left";
            }
            else if (goRight)
            {
                Settings.directions = "right";
            }
            else if (goDown)
            {
                Settings.directions = "down";
            }
            else if (goUp)
            {
                Settings.directions = "up";
            }
            // end of directions
            for (int i = Snake.Count - 1; i >= 0; i--) //Duyệt từ đuôi, xuống else để hiểu
            {
                if (i == 0) //Trường hợp duyệt tới đầu
                {
                    switch (Settings.directions) //Các trường hợp directions, vẽ trục tọa độ ta sẽ rõ
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }
                    //Các trường hợp chạm tường
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }
                    //Trường hợp ăn trái cây, để ở dưới các nút và các trường hợp xuyên tường
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }
                    //Trường hợp chạm vào chướng ngại
                    if (ChamChuongNgai(rec, Snake[0])) GameOver();
                    //Trường hợp chạm vào thân
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else //Phần tử sau bằng phần tử trước, lấy tọa độ mới
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            pictureBox1.Invalidate(); //Invalidate để picturebox vẽ lại
        }
        private void StartGame(object sender, EventArgs e) //Button start
        {
            RestartGame();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e) //Vẽ trên picturebox
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;
            canvas.FillRectangle(Brushes.Green, rec);
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Red; //Vẽ đầu rắng màu đỏ cho oách xà lách
                }
                else
                {
                    snakeColour = Brushes.Black; //thân rắn màu đen cho nổi
                }

                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    )); //Vẽ rắn là những hình Ellipse nối đuôi nhau, sau thay bằng Image khác
            }
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width, Settings.Height
            )); //Vẽ đồ ăn
        }
        private void AppearFood() //Hàm xuất hiện đồ ăn, loại trường hợp đồ ăn hiện ngay thân rắn
        {
            food = new Circles { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            bool k = true;
            for (int i = 0; i < Snake.Count; i++)
            {
                if (food.X == Snake[i].X && food.Y == Snake[i].Y) { k = false; break; }
            }
            if (!k) AppearFood();
        }
        private void EatFood() //Rắn ăn 1 quả sẽ dài thêm 1 nấc => list snake sẽ add 1 phần tử mới có tọa độ bằng tọa độ phần tử cuối của list cũ
        {
            score += 1; //Cộng điểm
            Circles body = new Circles
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);
            AppearFood();
        }
        private void RestartGame()
        {
            //Tính toán max dài và rộng của picturebox/sett.height và sett.width
            maxWidth = pictureBox1.Width / Settings.Width;
            maxHeight = pictureBox1.Height / Settings.Height;
            Snake.Clear(); //Xóa hết dữ liệu của snake cũ
            startButton.Enabled = false;
            score = 0;
            //Tạo 1 snake mới gồm 1 đầu và 1 nấc thân
            Circles head = new Circles { X = 10, Y = 5 };
            Snake.Add(head);
            for (int i = 0; i < 1; i++)
            {
                Circles body = new Circles();
                Snake.Add(body);
            }
            AppearFood(); //Đồ ăn xuất hiện
            timer1.Start(); //Timer chạy
        }
        private void GameOver()
        {
            startButton.Enabled = true;
            timer1.Stop();
        }

        private bool ChamChuongNgai(Rectangle a, Circles c) //Các trường hợp chạm chướng ngại ở các vị trí, sau này sẽ ghi rõ vào báo cáo
        {
            int x = a.X;
            int y = a.Y;
            int h = a.Height;
            int w = a.Width;
            if (c.X * Settings.Width <= x && c.Y * Settings.Height <= y)
                if (x < c.X * Settings.Width + Settings.Width && c.X * Settings.Width + Settings.Width <= x + w && y < c.Y * Settings.Height + Settings.Height && c.Y * Settings.Height + Settings.Height <= y + h) return true;
            if (c.X * Settings.Width > x && c.Y * Settings.Height <= y)
                if (x < c.X * Settings.Width && c.X * Settings.Width < x + w && y < c.Y * Settings.Height + Settings.Height && c.Y * Settings.Height + Settings.Height <= y + h) return true;
            if (c.X * Settings.Width <= x && c.Y * Settings.Height > y)
                if (x < c.X * Settings.Width + Settings.Width && c.X * Settings.Width + Settings.Height <= x + w && y < c.Y * Settings.Height && c.Y * Settings.Height < y + h) return true;
            if (c.X * Settings.Width > x && c.Y * Settings.Height > y)
                if (x < c.X * Settings.Width && c.X * Settings.Width < x + w && y < c.Y * Settings.Height && c.Y * Settings.Height < y + h) return true;
            return false;

        }
    }
}