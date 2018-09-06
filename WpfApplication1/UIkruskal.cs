using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Shapes;
namespace WpfApplication1
{
    class UIkruskal:prim
    {
        Canvas maincanvas;
        Canvas show;
        Canvas wait;
        Canvas product;
        public Canvas[] eillcanvas;
        public Point[] eillpoint;
        public Ellipse[] eill;
        public Canvas Moveedge { get; set; }
        /// <summary>
        /// 动画的时间轴
        /// </summary>
        private readonly Storyboard _storyboard;

        /// <summary>
        /// 动画的开始时间
        /// </summary>
        private double _beginTime;
        private double time;
        private Canvas[] waitedge;
        Rectangle[] rectangle;
        /// <summary>
        /// 布置画布的矩形的宽度
        /// </summary>
        private double Width;
        int [ ]vis;
        /// <summary>
        /// 布置画布的矩形的高度
        /// </summary>
        private double Height;
        List<Canvas>  valuecanvas;
        private bool[] usetext;
        private List<Line> useline;
        private int[] use;
        private List<int> linex;
        private List<int> liney;
        public UIkruskal(Canvas c)
        {
            
            base.init();
            maincanvas = new Canvas();
            maincanvas = c;
            _storyboard = new Storyboard();
            _beginTime = 0;
            time = 1;
            Width = 56.89;
            Height = 56.89;
            valuecanvas = new List<Canvas>();
            useline = new List<Line>();
            linex = new List<int>();
            liney = new List<int>();
            use = new int[num * num];
            for (int i = 0; i < num * num; i++)
                use[i] = 0;
            vis = new int[5];
            for (int i = 0; i < num; i++)
            {
                vis[i] = 0;
            }
        }
        //布置背景
        public void initback()
        {
            show = new Canvas();
            show.Background = Brushes.Pink;
            show.Opacity = 0.5;
            show.Width = Width*10;
            show.Height = Height*11;
            maincanvas.Children.Add(show);
            Canvas.SetTop(show, 1);
            Canvas.SetLeft(show, 1);

            /*wait = new Canvas();
            wait.Background = Brushes.Yellow;
            wait.Opacity = 0.3;
            wait.Width = Width * 7.9;
            wait.Height = Height * 10;
            maincanvas.Children.Add(wait);
            Canvas.SetTop(wait, 1);
            Canvas.SetRight(wait, 1);*/
        }
        //背景圆
        public void init()
        {
            string[] text = { "0" ,"1","2","3","4"};
            eillpoint = new Point[5];
            eillcanvas = new Canvas[5];
            eill = new Ellipse[5];
            eillpoint[0].X = show.Width / 4;
            eillpoint[0].Y = show.Height / 3.5*1.3 ;
            eillpoint[1].X = show.Width / 4*2;
            eillpoint[1].Y = show.Height / 10;
            eillpoint[2].X = show.Width / 4 * 2;
            eillpoint[2].Y = show.Height / 1.5;
            eillpoint[3].X = show.Width / 4*3.5;
            eillpoint[3].Y = show.Height / 5;
            eillpoint[4].X = show.Width / 4 * 3.5;
            eillpoint[4].Y = show.Height / 1.7;
            for (int i=0;i<5;i++)
            {
                Canvas newcan = new Canvas();
                Ellipse tempeill = new Ellipse
                {
                    Width = 70,
                    Height = 70,
                    Opacity = 1.0,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Green
                };
                
                newcan.Children.Add(tempeill);
                newcan.Width = tempeill.Width;
                newcan.Height = tempeill.Height;
                newcan.Opacity = 1;
                TextBlock num = new TextBlock();
                num.FontSize = 30;
                num.Text = text[i];
                newcan.Children.Add(num);
                Canvas.SetTop(num,newcan.Width/5);
                Canvas.SetLeft(num, newcan.Height/2.5);
                eillcanvas[i] = newcan;
                
            }
            
                show.Children.Add(eillcanvas[0]);
                Canvas.SetTop(eillcanvas[0], eillpoint[0].X);
                Canvas.SetLeft(eillcanvas[0], eillpoint[0].Y);

            show.Children.Add(eillcanvas[1]);
            Canvas.SetTop(eillcanvas[1], eillpoint[1].X);
            Canvas.SetLeft(eillcanvas[1], eillpoint[1].Y);

            show.Children.Add(eillcanvas[2]);
            Canvas.SetTop(eillcanvas[2], eillpoint[2].X);
            Canvas.SetLeft(eillcanvas[2], eillpoint[2].Y);

            show.Children.Add(eillcanvas[3]);
            Canvas.SetTop(eillcanvas[3], eillpoint[3].X);
            Canvas.SetLeft(eillcanvas[3], eillpoint[3].Y);

            show.Children.Add(eillcanvas[4]);
            Canvas.SetTop(eillcanvas[4], eillpoint[4].X);
            Canvas.SetLeft(eillcanvas[4], eillpoint[4].Y);
        }
        public void initline()
        {
            string[] text = { "0", "1", "2", "3", "4" ,"5","6","7","8","9","10"};
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < i; j++)
                {
                    if (Map[i, j] > 0&&Map[i,j]<11)
                    {
                        var myanmation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
                        var myanmation1 = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time/2)));
                        Line line = new Line();
                        linex.Add(i);
                        liney.Add(j);
                        line.Y1 = eillpoint[j].X + 35;
                        line.Y2 = eillpoint[i].X + 35;
                        line.X1 = eillpoint[j].Y + 35;
                        line.X2 = eillpoint[i].Y + 35;
                        line.Y1 = eillpoint[j].X + 35;
                        line.Y2 = eillpoint[i].X + 35;
                        line.X1 = eillpoint[j].Y + 35;
                        line.X2 = eillpoint[i].Y + 35;
                        if (line.Y1 > line.Y2)
                        {
                            double siny = (line.Y1 - line.Y2) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            double sinx = (line.X1 - line.X2) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            if (line.X1 < line.X2)
                            {
                                line.X1 = line.X1 - 35 * sinx;
                                line.Y1 = line.Y1 - 35 * siny;
                                line.X2 = line.X2 + 35 * sinx;
                                line.Y2 = line.Y2 + 35 * siny;
                            }
                            else if (line.X1 > line.X2)
                            {
                                line.X1 = line.X1 - 35 * sinx;

                                line.Y1 = line.Y1 - 35 * siny;
                                line.X2 = line.X2 + 35 * sinx;
                                line.Y2 = line.Y2 + 35 * siny;
                            }
                            else
                            {
                                line.Y2 += 35;
                                line.Y1 -= 35;
                            }
                        }
                        else if (line.Y1 < line.Y2)
                        {
                            double siny = (line.Y2 - line.Y1) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            double sinx = (line.X2 - line.X1) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            if (line.X1 < line.X2)
                            {
                                line.X1 = line.X1 + 35 * sinx;
                                line.Y1 = line.Y1 + 35 * siny;
                                line.X2 = line.X2 - 35 * sinx;

                                line.Y2 = line.Y2 - 35 * siny;
                            }
                            else if (line.X1 > line.X2)
                            {
                                line.X1 = line.X1 + 35 * sinx;
                                line.Y1 = line.Y1 + 35 * siny;
                                line.X2 = line.X2 - 35 * sinx;
                                line.Y2 = line.Y2 - 35 * siny;
                            }
                            else
                            {
                                line.Y1 += 35;
                                line.Y2 -= 35;
                            }
                        }
                        else
                        {
                            if (line.X1 < line.X2)
                            {
                                line.X1 += 35;
                                line.X2 -= 35;
                            }
                            else
                            {
                                line.X1 -= 35;
                                line.X2 += 35;
                            }
                        }
                        TextBlock value = new TextBlock();
                        value.FontSize = 25;
                        value.Text = text[Map[i, j]];
                        value.Opacity = 0;
                        Canvas valuecanva = new Canvas();
                        valuecanva.Children.Add(value);
                        valuecanvas.Add(valuecanva);
                        line.Opacity = 0;
                       
                            line.Stroke = Brushes.Green;
                        line.StrokeThickness = 5;
                        useline.Add(line);
                        Storyboard.SetTarget(myanmation, line);
                        Storyboard.SetTargetProperty(myanmation, new PropertyPath(UIElement.OpacityProperty));
                        myanmation.BeginTime = TimeSpan.FromSeconds(_beginTime);
                        myanmation.FillBehavior = FillBehavior.HoldEnd;
                        _beginTime += time;
                        myanmation1.BeginTime = TimeSpan.FromSeconds(_beginTime);
                        myanmation1.FillBehavior = FillBehavior.HoldEnd;
                        _beginTime += time/2;
                        Storyboard.SetTarget(myanmation1, value);
                        Storyboard.SetTargetProperty(myanmation1, new PropertyPath(UIElement.OpacityProperty));
                        _storyboard.Children.Add(myanmation);
                        _storyboard.Children.Add(myanmation1);
                        show.Children.Add(line);
                        show.Children.Add(valuecanva);
                        Canvas.SetLeft(valuecanva,(line.X1+line.X2)/2);
                        Canvas.SetTop(valuecanva, (line.Y1 + line.Y2) / 2);


                    }
                }

        }
        public void treework()
        {
            string[] text = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            int cnt = 1;
            for (int k=0;k<5;k++)
            {
                
                base.work(k);
                var myanmation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(time)));
                int i = usededge[k,0];
                int j = usededge[k,1];
                /*if(i<j)
                {
                    int temp;
                    temp = i;
                    i = j;
                    j = temp;
                }*/
                vis[i] = 1;
                
                Ellipse tempeill = new Ellipse
                {
                    Width = 70,
                    Height = 70,
                    Opacity = 0.0,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Red
                };
                show.Children.Add(tempeill);

                Canvas.SetTop(tempeill, eillpoint[i].X);
                Canvas.SetLeft(tempeill, eillpoint[i].Y);
                DoubleAnimation myanm = new DoubleAnimation();
                myanm.From = 0;
                myanm.To = 1;
                myanm.Duration = new Duration(TimeSpan.FromSeconds(time));
                Storyboard.SetTarget(myanm, tempeill);
                Storyboard.SetTargetProperty(myanm, new PropertyPath(UIElement.OpacityProperty));
                myanm.BeginTime = TimeSpan.FromSeconds(_beginTime);
                myanm.FillBehavior = FillBehavior.HoldEnd;
                _storyboard.Children.Add(myanm);
                _beginTime += time;
                TextBlock num = new TextBlock();
                num.FontSize = 30;
                num.Text = text[i];
                show.Children.Add(num);
                Canvas.SetTop(num, eillpoint[i].X + tempeill.Width / 5);
                Canvas.SetLeft(num, eillpoint[i].Y + tempeill.Height / 2.5);
                string str = text[i];
                TextBlock Text = new TextBlock
                {
                    FontSize = 40,
                    Text = str,
                    Opacity = 0
                };
                show.Children.Add(Text);
                Canvas.SetLeft(Text, Width*(cnt++));
                Canvas.SetTop(Text, Width * 1);
                var myanm1 = new DoubleAnimation();
                myanm1.From = 0;
                myanm1.To = 1;
                myanm1.Duration = new Duration(TimeSpan.FromSeconds(time));
                Storyboard.SetTarget(myanm1, Text);
                Storyboard.SetTargetProperty(myanm1, new PropertyPath(UIElement.OpacityProperty));
                myanm1.BeginTime = TimeSpan.FromSeconds(_beginTime);
                myanm1.FillBehavior = FillBehavior.HoldEnd;
                _storyboard.Children.Add(myanm1);
                _beginTime += time;

                for (int kk=0;kk<5;kk++)
                {
                    if(vis[kk]==0&&Map[i,kk]!=11)
                    {
                        vis[kk] = 1;
                        Line line = new Line();
                        line.Y1 = eillpoint[i].X + 35;
                        line.Y2 = eillpoint[kk].X + 35;
                        line.X1 = eillpoint[i].Y + 35;
                        line.X2 = eillpoint[kk].Y + 35;
                        if (line.Y1 > line.Y2)
                        {
                            double siny = (line.Y1 - line.Y2) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            double sinx = (line.X1 - line.X2) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            if (line.X1 < line.X2)
                            {
                                line.X1 = line.X1 - 35 * sinx;
                                line.Y1 = line.Y1 - 35 * siny;
                                line.X2 = line.X2 + 35 * sinx;
                                line.Y2 = line.Y2 + 35 * siny;
                            }
                            else if (line.X1 > line.X2)
                            {
                                line.X1 = line.X1 - 35 * sinx;

                                line.Y1 = line.Y1 - 35 * siny;
                                line.X2 = line.X2 + 35 * sinx;
                                line.Y2 = line.Y2 + 35 * siny;
                            }
                            else
                            {
                                line.Y2 += 35;
                                line.Y1 -= 35;
                            }
                        }
                        else if (line.Y1 < line.Y2)
                        {
                            double siny = (line.Y2 - line.Y1) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            double sinx = (line.X2 - line.X1) / Math.Pow((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2), 0.5);
                            if (line.X1 < line.X2)
                            {
                                line.X1 = line.X1 + 35 * sinx;
                                line.Y1 = line.Y1 + 35 * siny;
                                line.X2 = line.X2 - 35 * sinx;

                                line.Y2 = line.Y2 - 35 * siny;
                            }
                            else if (line.X1 > line.X2)
                            {
                                line.X1 = line.X1 + 35 * sinx;
                                line.Y1 = line.Y1 + 35 * siny;
                                line.X2 = line.X2 - 35 * sinx;
                                line.Y2 = line.Y2 - 35 * siny;
                            }
                            else
                            {
                                line.Y1 += 35;
                                line.Y2 -= 35;
                            }
                        }
                        else
                        {
                            if (line.X1 < line.X2)
                            {
                                line.X1 += 35;
                                line.X2 -= 35;
                            }
                            else
                            {
                                line.X1 -= 35;
                                line.X2 += 35;
                            }
                        }
                        line.StrokeThickness = 10;
                        line.Stroke = Brushes.Blue;
                        DoubleAnimation da1 = new DoubleAnimation();
                        line.Opacity = 0;
                        da1.From = 0.0;

                        da1.To = 1;
                        da1.Duration = TimeSpan.FromSeconds(1);
                        da1.BeginTime = TimeSpan.FromSeconds(_beginTime);
                        Storyboard.SetTarget(da1, line);
                        Storyboard.SetTargetProperty(da1, new PropertyPath(UIElement.OpacityProperty));
                        show.Children.Add(line);
                        da1.FillBehavior = FillBehavior.HoldEnd;
                        _storyboard.Children.Add(da1);
                        _beginTime += 2;

                        /*useline[k].Stroke = Brushes.Green;
                        da = new DoubleAnimation();
                        useline[k].Opacity = 0.5;
                        da.From = 0.5;

                        da.To = 1;
                        da.Duration = TimeSpan.FromSeconds(1);
                        da.BeginTime = TimeSpan.FromSeconds(_beginTime);
                        Storyboard.SetTarget(da, useline[k]);
                        Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                        da.FillBehavior = FillBehavior.HoldEnd;
                        _storyboard.Children.Add(da);
                        _beginTime += 1;*/
                        
                        
                    }
                    
                }
                Line line1 = new Line();
                line1.Y1 = eillpoint[i].X + 35;
                line1.Y2 = eillpoint[j].X + 35;
                line1.X1 = eillpoint[i].Y + 35;
                line1.X2 = eillpoint[j].Y + 35;
                if (line1.Y1 > line1.Y2)
                {
                    double siny = (line1.Y1 - line1.Y2) / Math.Pow((line1.X1 - line1.X2) * (line1.X1 - line1.X2) + (line1.Y1 - line1.Y2) * (line1.Y1 - line1.Y2), 0.5);
                    double sinx = (line1.X1 - line1.X2) / Math.Pow((line1.X1 - line1.X2) * (line1.X1 - line1.X2) + (line1.Y1 - line1.Y2) * (line1.Y1 - line1.Y2), 0.5);
                    if (line1.X1 < line1.X2)
                    {
                        line1.X1 = line1.X1 - 35 * sinx;
                        line1.Y1 = line1.Y1 - 35 * siny;
                        line1.X2 = line1.X2 + 35 * sinx;
                        line1.Y2 = line1.Y2 + 35 * siny;
                    }
                    else if (line1.X1 > line1.X2)
                    {
                        line1.X1 = line1.X1 - 35 * sinx;

                        line1.Y1 = line1.Y1 - 35 * siny;
                        line1.X2 = line1.X2 + 35 * sinx;
                        line1.Y2 = line1.Y2 + 35 * siny;
                    }
                    else
                    {
                        line1.Y2 += 35;
                        line1.Y1 -= 35;
                    }
                }
                else if (line1.Y1 < line1.Y2)
                {
                    double siny = (line1.Y2 - line1.Y1) / Math.Pow((line1.X1 - line1.X2) * (line1.X1 - line1.X2) + (line1.Y1 - line1.Y2) * (line1.Y1 - line1.Y2), 0.5);
                    double sinx = (line1.X2 - line1.X1) / Math.Pow((line1.X1 - line1.X2) * (line1.X1 - line1.X2) + (line1.Y1 - line1.Y2) * (line1.Y1 - line1.Y2), 0.5);
                    if (line1.X1 < line1.X2)
                    {
                        line1.X1 = line1.X1 + 35 * sinx;
                        line1.Y1 = line1.Y1 + 35 * siny;
                        line1.X2 = line1.X2 - 35 * sinx;

                        line1.Y2 = line1.Y2 - 35 * siny;
                    }
                    else if (line1.X1 > line1.X2)
                    {
                        line1.X1 = line1.X1 + 35 * sinx;
                        line1.Y1 = line1.Y1 + 35 * siny;
                        line1.X2 = line1.X2 - 35 * sinx;
                        line1.Y2 = line1.Y2 - 35 * siny;
                    }
                    else
                    {
                        line1.Y1 += 35;
                        line1.Y2 -= 35;
                    }
                }
                else
                {
                    if (line1.X1 < line1.X2)
                    {
                        line1.X1 += 35;
                        line1.X2 -= 35;
                    }
                    else
                    {
                        line1.X1 -= 35;
                        line1.X2 += 35;
                    }
                }
                line1.StrokeThickness = 10;
                line1.Stroke = Brushes.Red;
                DoubleAnimation da = new DoubleAnimation();
                line1.Opacity = 0;
                da.From = 0.0;

                da.To = 1;
                da.Duration = TimeSpan.FromSeconds(1);
                da.BeginTime = TimeSpan.FromSeconds(_beginTime);
                Storyboard.SetTarget(da, line1);
                Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                show.Children.Add(line1);
                da.FillBehavior = FillBehavior.HoldEnd;
                _storyboard.Children.Add(da);
                _beginTime += time;

                tempeill = new Ellipse
                {
                    Width = 70,
                    Height = 70,
                    Opacity = 0.0,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Red
                };
                show.Children.Add(tempeill);

                Canvas.SetTop(tempeill, eillpoint[j].X);
                Canvas.SetLeft(tempeill, eillpoint[j].Y);
                 myanm = new DoubleAnimation();
                myanm.From = 0;
                myanm.To = 1;
                myanm.Duration = new Duration(TimeSpan.FromSeconds(time));
                Storyboard.SetTarget(myanm, tempeill);
                Storyboard.SetTargetProperty(myanm, new PropertyPath(UIElement.OpacityProperty));
                myanm.BeginTime = TimeSpan.FromSeconds(_beginTime);
                myanm.FillBehavior = FillBehavior.HoldEnd;
                _storyboard.Children.Add(myanm);
                _beginTime += time;
                num = new TextBlock();
                num.FontSize = 30;
                num.Text = text[j];
                show.Children.Add(num);
                Canvas.SetTop(num, eillpoint[j].X + tempeill.Width / 5);
                Canvas.SetLeft(num, eillpoint[j].Y + tempeill.Height / 2.5);
                _beginTime += time;

                /*myanm1.From = 1;
                myanm1.To = 0;
                myanm1.Duration = new Duration(TimeSpan.FromSeconds(time));
                Storyboard.SetTarget(myanm1, Text);
                Storyboard.SetTargetProperty(myanm1, new PropertyPath(UIElement.OpacityProperty));
                myanm1.BeginTime = TimeSpan.FromSeconds(_beginTime);
                myanm1.FillBehavior = FillBehavior.HoldEnd;
                _storyboard.Children.Add(myanm1);
                _beginTime += time;*/
            }
        }
      
        public void beginStoryBoard()
        {
            _storyboard.Begin();
        }
        
    }
}
