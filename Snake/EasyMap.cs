using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class EasyMap : Form
    {
        public EasyMap()
        {
            InitializeComponent();
        }
        List<Circles> Snake = new List<Circles>(); //Tạo list chứa các Circles
        private Circles food = new Circles(); //Tạo biến food
        int maxWidth; //Chiều rộng tối đa của map
        int maxHeight; //Chiều dài tối đa của map
        int score; //Điểm
        int highScore; //Điểm kỉ lục
        Random rand = new Random();
        bool goLeft, goRight, goDown, goUp; //các biến bool mũi tên
        List<Rectangle> rects = new List<Rectangle>();
        Image moi = Settings.Instance.food;
        StringFormat format = new StringFormat
        {
            Alignment = StringAlignment.Center,      // Căn giữa theo chiều ngang
            LineAlignment = StringAlignment.Center  // Căn giữa theo chiều dọc
        };

        bool k = false;
        string result = "";
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
                    //Trường hợp chạm vào thân
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Settings.Instance.soundHit.Play();
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

        private void EasyMap_KeyDown(object sender, KeyEventArgs e)
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

        private void EasyMap_KeyUp(object sender, KeyEventArgs e)
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
        Modify Modify = new Modify();

        private void EasyMap_Load(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) //Vẽ trên picturebox
        {
            Graphics canvas = e.Graphics;
            canvas.DrawString("SCORE: " + score, new Font("Tahoma", 14, FontStyle.Bold), Brushes.Yellow, 600, 0);
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    if (Settings.directions == "left")
                    {
                        canvas.DrawImage(Properties.Resources.head_left, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }
                    else if (Settings.directions == "right")
                    {
                        canvas.DrawImage(Properties.Resources.head_right, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }
                    else if (Settings.directions == "up")
                    {
                        canvas.DrawImage(Properties.Resources.head_up, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }
                    else
                    {
                        canvas.DrawImage(Properties.Resources.head_down, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }
                }
                else if (i == Snake.Count - 1)
                {
                    if (Snake[i].X == Snake[i - 1].X && Snake[i - 1].Y == 0 && Snake[i].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.tail_up, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].X == Snake[i - 1].X && Snake[i].Y == 0 && Snake[i - 1].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.tail_down, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].X == 0 && Snake[i - 1].X == maxWidth)
                    {
                        canvas.DrawImage(Properties.Resources.tail_right, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i - 1].X == 0 && Snake[i].X == maxWidth)
                    {
                        canvas.DrawImage(Properties.Resources.tail_left, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].X == Snake[i - 1].X && Snake[i].Y > Snake[i - 1].Y)
                    {
                        canvas.DrawImage(Properties.Resources.tail_down, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].X == Snake[i - 1].X && Snake[i].Y < Snake[i - 1].Y)
                    {
                        canvas.DrawImage(Properties.Resources.tail_up, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }
                    else if (Snake[i].X < Snake[i - 1].X && Snake[i].Y == Snake[i - 1].Y)
                    {
                        canvas.DrawImage(Properties.Resources.tail_left, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }
                    else if (Snake[i].X > Snake[i - 1].X && Snake[i].Y == Snake[i - 1].Y)
                    {
                        canvas.DrawImage(Properties.Resources.tail_right, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                }
                else
                {
                    if (Snake[i].X == Snake[i - 1].X && Snake[i].X == Snake[i + 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_vertical, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].X == 0 && Snake[i].Y == maxHeight && ((Snake[i - 1].X == 0 && Snake[i - 1].Y == 0 && Snake[i + 1].X == maxWidth && Snake[i + 1].Y == maxHeight) || (Snake[i + 1].X == 0 && Snake[i + 1].Y == 0 && Snake[i - 1].X == maxWidth && Snake[i - 1].Y == maxHeight)))
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].X == maxWidth && Snake[i].Y == 0 && ((Snake[i - 1].X == 0 && Snake[i - 1].Y == 0 && Snake[i + 1].X == maxWidth && Snake[i + 1].Y == maxHeight) || (Snake[i + 1].X == 0 && Snake[i + 1].Y == 0 && Snake[i - 1].X == maxWidth && Snake[i - 1].Y == maxHeight)))
                    {
                        canvas.DrawImage(Properties.Resources.body_topright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].X == 0 && Snake[i].Y == 0 && ((Snake[i - 1].X == 0 && Snake[i - 1].Y == maxHeight && Snake[i + 1].X == maxWidth && Snake[i + 1].Y == 0) || (Snake[i + 1].X == 0 && Snake[i + 1].Y == maxHeight && Snake[i - 1].X == maxWidth && Snake[i - 1].Y == 0)))
                    {
                        canvas.DrawImage(Properties.Resources.body_topleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].X == maxWidth && Snake[i].Y == maxHeight && ((Snake[i - 1].X == 0 && Snake[i - 1].Y == maxHeight && Snake[i + 1].X == maxWidth && Snake[i + 1].Y == 0) || (Snake[i + 1].X == 0 && Snake[i + 1].Y == maxHeight && Snake[i - 1].X == maxWidth && Snake[i - 1].Y == 0)))
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].X == Snake[i + 1].X && Snake[i].X > Snake[i - 1].X && Snake[i].Y == 0 && Snake[i + 1].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.body_topleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i + 1].Y && Snake[i].X == Snake[i - 1].X && Snake[i].X > Snake[i + 1].X && Snake[i].Y == 0 && Snake[i - 1].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.body_topleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].X == Snake[i + 1].X && Snake[i].Y > Snake[i + 1].Y && Snake[i].X == 0 && Snake[i - 1].X == maxWidth)
                    {
                        canvas.DrawImage(Properties.Resources.body_topleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i + 1].Y && Snake[i].X == Snake[i - 1].X && Snake[i].Y > Snake[i - 1].Y && Snake[i].X == 0 && Snake[i + 1].X == maxWidth)
                    {
                        canvas.DrawImage(Properties.Resources.body_topleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i + 1].Y && Snake[i].X == Snake[i - 1].X && Snake[i].X < Snake[i + 1].X && Snake[i].Y == 0 && Snake[i - 1].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.body_topright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].X == Snake[i + 1].X && Snake[i].X < Snake[i - 1].X && Snake[i].Y == 0 && Snake[i + 1].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.body_topright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].X == Snake[i + 1].X && Snake[i].Y > Snake[i + 1].Y && Snake[i].X == maxWidth && Snake[i - 1].X == 0)
                    {
                        canvas.DrawImage(Properties.Resources.body_topright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i + 1].Y && Snake[i].X == Snake[i - 1].X && Snake[i].Y > Snake[i - 1].Y && Snake[i].X == maxWidth && Snake[i + 1].X == 0)
                    {
                        canvas.DrawImage(Properties.Resources.body_topright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y < Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y && Snake[i].X == maxWidth && Snake[i + 1].X == 0)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].X == Snake[i + 1].X && Snake[i].X > Snake[i - 1].X && Snake[i + 1].Y == 0 && Snake[i].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i + 1].Y && Snake[i].X == Snake[i - 1].X && Snake[i].X < Snake[i + 1].X && Snake[i - 1].Y == 0 && Snake[i].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y < Snake[i + 1].Y && Snake[i].X > Snake[i - 1].X && Snake[i - 1].X == 0 && Snake[i].X == maxWidth)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y == maxHeight && Snake[i + 1].Y == 0)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y < Snake[i + 1].Y && Snake[i].X < Snake[i - 1].X && Snake[i].X == 0 && Snake[i - 1].X == maxWidth)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y < Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y && Snake[i].X < Snake[i + 1].X && Snake[i].X == 0 && Snake[i + 1].X == maxWidth)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y > Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y && Snake[i].X == Snake[i - 1].X && Snake[i - 1].Y == 0 && Snake[i].Y == maxHeight)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }



                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y < Snake[i + 1].Y && Snake[i].X > Snake[i - 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y < Snake[i + 1].Y && Snake[i].X < Snake[i - 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y > Snake[i + 1].Y && Snake[i].X > Snake[i - 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_topleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y > Snake[i + 1].Y && Snake[i].X < Snake[i - 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_topright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y == Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y)
                    {
                        canvas.DrawImage(Properties.Resources.body_horizontal, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y < Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y && Snake[i].X > Snake[i + 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y < Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y && Snake[i].X < Snake[i + 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_bottomright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y > Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y && Snake[i].X > Snake[i + 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_topleft, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }

                    else if (Snake[i].Y > Snake[i - 1].Y && Snake[i].Y == Snake[i + 1].Y && Snake[i].X < Snake[i + 1].X)
                    {
                        canvas.DrawImage(Properties.Resources.body_topright, new Rectangle
                    (
                    Snake[i].X * Settings.Height,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
                    }
                }

            }
            canvas.DrawImage(moi, new Rectangle
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
            for (int j = 0; j < rects.Count; j++)
                if (ChamChuongNgai(rects[j], food))
                {
                    k = false;
                    break;
                }
            if (!k) AppearFood();
        }
        private void EatFood() //Rắn ăn 1 quả sẽ dài thêm 1 nấc => list snake sẽ add 1 phần tử mới có tọa độ bằng tọa độ phần tử cuối của list cũ
        {
            Settings.Instance.soundEat.Play(); //Âm thanh
            score += 10; //Cộng điểm

            if (score == 50) timer1.Interval -= 5;
            if (score == 100) timer1.Interval -= 5;
            if (score == 150) timer1.Interval -= 5;
            if (score == 200) timer1.Interval -= 5;
            if (score == 250) timer1.Interval -= 5;
            if (score == 300) timer1.Interval -= 5;
            if (score == 350) timer1.Interval -= 5;
            if (score == 400) timer1.Interval -= 5;

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
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = '" + Settings.Instance.TenTK + "'";
            highScore = Modify.TaiKhoans(query)[0].easyPoint;

            Settings.directions = "right";
            k = true;
            //Tính toán max dài và rộng của picturebox/sett.height và sett.width
            maxWidth = pictureBox1.Width / Settings.Width - 1;
            maxHeight = pictureBox1.Height / Settings.Height - 1;
            Snake.Clear(); //Xóa hết dữ liệu của snake cũ
            score = 0;
            //Tạo 1 snake mới gồm 1 đầu và 1 nấc thân
            Circles head = new Circles { X = 0, Y = 0 };
            Snake.Add(head);
            for (int i = 0; i < 1; i++)
            {
                Circles body = new Circles();
                Snake.Add(body);
            }
            rects.Clear();
            AppearFood(); //Đồ ăn xuất hiện
            timer1.Start(); //Timer chạy
        }
        private void GameOver()
        {
            Settings.Instance.Score = score;
            if (score > highScore)
            {
                string query = "UPDATE TaiKhoan SET EasyPoint = " + score + " WHERE TenTK = '" + Settings.Instance.TenTK + "'";
                Modify.Command(query);
            }

            score = 0;
            k = false;
            timer1.Stop();
            GameOver gameOver = new GameOver();
            System.Threading.Thread.Sleep(1000);
            this.Hide();
            gameOver.ShowDialog();
            this.Close();

        }
        private bool ChamChuongNgai(Rectangle a, Circles c)
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
