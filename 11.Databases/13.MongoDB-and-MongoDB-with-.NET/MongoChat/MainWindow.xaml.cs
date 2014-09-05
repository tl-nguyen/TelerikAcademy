namespace MongoChat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;

    using MongoChat.Controllers;
    using MongoChat.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;
        private ChatController chatCtrl;
        private List<Message> currentMessages;

        public MainWindow()
        {
            this.chatCtrl = new ChatController();
            this.currentMessages = chatCtrl.GetAllMessages();
            InitializeComponent();

            foreach (var message in currentMessages)
            {
                this.VisualizeMessage(message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TbMessage.Text != "")
            {
                var message = new Message
                {
                    Text = TbMessage.Text,
                    User = new User
                    {
                        Username = TbUsername.Text
                    },
                    Date = DateTime.Now
                };

                this.chatCtrl.SendMessage(message);
                this.GetLastPosts();
                TbMessage.Text = "";
            }
            else
            {
                this.GetLastPosts();
            }
        }

        private void VisualizeMessage(Message message)
        {
            LbMessages.Items.Add(String.Format("{0} : {1}", message.User.Username, message.Text).ToString());

            LbMessages.SelectedIndex = LbMessages.Items.Count -1;
            LbMessages.ScrollIntoView(LbMessages.SelectedItem);
        }

        private void GetLastPosts()
        {
            var lastPosts = chatCtrl.GetLastMessages(this.currentMessages.Last().Date);

            foreach (var message in lastPosts)
            {
                VisualizeMessage(message);
            }

            currentMessages.AddRange(lastPosts);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.username = TbUsername.Text;
        }
    }
}
