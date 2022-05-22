using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class Form1 : Form
    {
        private readonly HubConnection hubConnection;
        public Form1()
        {
            InitializeComponent();

            //создаем hubConnection
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:15980/messages")
                .WithAutomaticReconnect()
                .Build();
            //настраиваем hubConnection, назначаем ему обработчик метода Send
            //будет приниматься newMessage
            //получаем сообщение и выводим его в textBox
            //принимает 3 параметра отправитьель, техст сообщения и цвет сообщения
            hubConnection.On<NewMessage>("Send", message =>
            {
                AppendTextToTextBox(message.Sender, message.Text, Color.Black);
            });
            //подптсываемся на 3 события жизненного цикла подключения
            //1. закрытие 2. событие успешное подключение 3.событие попытки переподключения reconnecting
            //во всех случаях мы выводим информацию с помощью messagebox о том что событие произошло
            //событие closed передает объект ошибки
            //событие reconnected передает connection id, с которым мы переподключились к серверу
            //событие reconecting передает объект ошибки, почему происходит переподключение

            hubConnection.Closed += error =>
            {
                MessageBox.Show($"Connection closed.{error.Message}");
                return Task.CompletedTask;
            };

            hubConnection.Reconnected += id =>
            {
                MessageBox.Show($"Connection reconnected with id:{id}");
                return Task.CompletedTask;
            };

            hubConnection.Reconnecting += error =>
            {
                MessageBox.Show($"Connection reconnecting.{error.Message} ");
                return Task.CompletedTask;
            };

        }

        private void AppendTextToTextBox(string sender, string text, Color color)
        {
            chatTextBox.SelectionStart = chatTextBox.TextLength;
            chatTextBox.SelectionLength = 0;
            chatTextBox.SelectionColor = color;
            chatTextBox.AppendText(string.Format("Author:{0}{2}Text:{1}{2}{2}", sender, text, Environment.NewLine));
            chatTextBox.SelectionColor = chatTextBox.ForeColor;
        }

        //по кнопке Connect проверяем если наше соединение Disconected, вызываем startasinc для инициализации
        //подключения, все обернули в try catch и если выпало исключение то программа не закроется аварийно
        //а выведется ошибка
       
        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await hubConnection.StartAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (hubConnection.State == HubConnectionState.Connected)
                {
                    connectButton.Text = "Disconnect";
                    stateLabelValue.ForeColor = Color.Green;
                    stateLabelValue.Text = "Connected";
                }
            }
            else if (hubConnection.State == HubConnectionState.Connected)
            {
                await hubConnection.StopAsync();
                connectButton.Text = "Connect";
                stateLabelValue.ForeColor = Color.Red;
                stateLabelValue.Text = "Disconnected";
            }
        }

        //в обработчике кнопки мы смлтрим если состояние нашего соединения открыто
        //мы пытаемся получить с сервера наше имя для этого вызываем InvokeAsync дженерик версию и 
        //указываем что ответ сервера будет типа стринг имя на сервере getmyname
        private async void getNameButton_Click(object sender, EventArgs e)
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                try
                {
                    var name = await hubConnection.InvokeAsync<string>("GetMyName");
                    if (string.IsNullOrWhiteSpace(name))
                        nameTextBox.Text = name;
                    else
                        nameTextBox.Text = name;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //при нажатии на кнопку set обработчик проверит открыто ли подключение и попытается передать наше новое имя
        //с помощью метода sendAsync метод на сервере setmyname
        private async void setNameButton_Click(object sender, EventArgs e)
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                try
                {
                    await hubConnection.SendAsync("SetMyName", nameTextBox.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //обработчик кнопки send смотрим открыто ли соединениеи создается новый объект типа message
        //в поле text записывается содержимое нашего messagebox
        //и пытается отправить на сервер с помощью метода sendtoOthers наше сообщение
        //и в любом случае удачно или нет отправлено сообщение очищаем messageTextBox
        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                var message = new Message
                {
                    Text = messageTextBox.Text
                };
                try
                {
                    await hubConnection.SendAsync("SendToOthers", message);
                    AppendTextToTextBox("Me", message.Text, Color.Green);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    messageTextBox.Clear();
                }
                
                
            
            }
        }
    }
}
