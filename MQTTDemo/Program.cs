using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;

namespace MQTTDemo {
    class Program {
        private static IMqttClient mqttClient = null;
        private static string topic = "/mqtt/topic/0";
        private static string oprate = "";
        private static string mqttIP = "192.168.60.197";
        private static int mqttPort = 1883;
        
        static void Main (string[] args) {
            Console.WriteLine ("Hello MQTT!");
            Console.WriteLine ("请输入MQTT服务器IP：");
            string tempIp = Console.ReadLine ();
            if (!string.IsNullOrWhiteSpace (tempIp)) {
                mqttIP = tempIp;
            }
            Console.WriteLine ("请输入MQTT服务器端口号：");
            int.TryParse (Console.ReadLine (), out int tempPort);
            if (tempPort > 0) {
                mqttPort = tempPort;
            }
            Console.WriteLine ("请输入您要订阅的主题：");
            string temp = Console.ReadLine ();
            if (!string.IsNullOrWhiteSpace (temp)) {
                topic = temp;
            }
            Console.WriteLine (string.Format ("已设置 IP:{0} port:{1},主题：{2}", mqttIP, mqttPort, topic));

            Console.WriteLine (string.Format ("订阅主题为：{0}", topic));

            var task = new Task (async () => {
                if (mqttClient == null) {
                    mqttClient = new MqttFactory ().CreateMqttClient ();
                    mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                    mqttClient.Connected += MqttClient_Connected;
                    mqttClient.Disconnected += MqttClient_Disconnected;
                }
                try {
                    var opt = new MqttClientOptions () {
                        ClientId = Guid.NewGuid ().ToString (),
                        ChannelOptions = new MqttClientTcpOptions {
                        Server = mqttIP,
                        Port = mqttPort
                        }
                    };
                    await mqttClient.ConnectAsync (opt);
                    await mqttClient.SubscribeAsync (new List<TopicFilter> {
                        new TopicFilter (topic, MqttQualityOfServiceLevel.AtMostOnce)
                    });
                } catch (Exception ex) {
                    Console.WriteLine ("连接到MQTT服务器失败！!" + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            });

            task.Start ();

            string userCommand = "";
            while (userCommand != "exit") {
                userCommand = Console.ReadLine ();
                if (userCommand == "help") {
                    Console.WriteLine ("set 设置主题");
                    Console.WriteLine ("send 发送");
                    Console.WriteLine ("quit 退出发送");
                    Console.WriteLine ("exit 退出程序");
                }

                if (userCommand == "send") {
                    oprate = "send";
                    Console.WriteLine ("已设置，请输入您要发送的内容:");
                } else {
                    if (oprate == "send") {
                        var appMsg = new MqttApplicationMessage () {
                        Payload = Encoding.UTF8.GetBytes (userCommand),
                        QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
                        Retain = false,
                        Topic = topic
                        };
                        mqttClient.PublishAsync (appMsg);
                        Console.WriteLine ("已发送，请继续输入您要发送的内容：");
                    }
                }

                if (userCommand == "quit") {
                    oprate = "";
                }

            }
            Console.ReadKey ();
        }

        private static void MqttClient_Connected (object sender, EventArgs e) {
            Console.WriteLine ("已连接到MQTT服务器！" + Environment.NewLine);
        }

        private static void MqttClient_Disconnected (object sender, EventArgs e) {
            Console.WriteLine ("已断开MQTT连接！" + Environment.NewLine);
        }

        private static void MqttClient_ApplicationMessageReceived (object sender, MqttApplicationMessageReceivedEventArgs e) {

            Console.WriteLine ($">> {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}{Environment.NewLine}");
        }

    }
}