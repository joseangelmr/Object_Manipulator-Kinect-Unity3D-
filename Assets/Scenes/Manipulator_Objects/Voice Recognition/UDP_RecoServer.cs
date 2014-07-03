    // *********************************************************
    // UDP SPEECH RECOGNITION
    // *********************************************************
    using UnityEngine;
    using System.Collections;
    using System;
    using System.Net;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading;

	using HutongGames.PlayMaker;

 
    public class UDP_RecoServer : MonoBehaviour
    {
       Thread receiveThread;
       UdpClient client;
       public int port = 26000; // DEFAULT UDP PORT !!!!! THE QUAKE ONE ;)
       string strReceiveUDP = "";
       string LocalIP = String.Empty;
       string hostname;
	   public GUIText mensaje;
	   public FsmString str;
	   
	
       public void Start()
       {
		  //var globalVariables = FsmVariables.GlobalVariables;
		  //var numLives = globalVariables.GetFsmString("string_voz");
	      //numLives.Value = "3";
		  //str= FsmVariables.GlobalVariables.GetFsmString("string_voz");
		  //mensaje= GameObject.Find("GUI Text_Hands_Rotate_Vertical").guiText;
		  Application.runInBackground = true;
          init(); 
		
		
       }
       // init
       private void init()
       {
          receiveThread = new Thread( new ThreadStart(ReceiveData));
          receiveThread.IsBackground = true;
          receiveThread.Start();
          hostname = Dns.GetHostName();
          IPAddress[] ips = Dns.GetHostAddresses(hostname);
          if (ips.Length > 0)
          {
             LocalIP = ips[0].ToString();
             //Debug.Log(" MY IP : "+LocalIP);
          }
       }
 
       private  void ReceiveData()
       {
          client = new UdpClient(port);
          while (true)
          {
             try
             {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast, port);
                byte[] data = client.Receive(ref anyIP);
                strReceiveUDP = Encoding.UTF8.GetString(data);
                // ***********************************************************************
                // Simple Debug. Must be replaced with SendMessage for example.
                // ***********************************************************************
                Debug.Log(strReceiveUDP);
				//str.Value=strReceiveUDP;
				
                // ***********************************************************************
             }
             catch (Exception err)
             {
                print(err.ToString());
             }
          }
       }
 
       public string UDPGetPacket()
       {
          return strReceiveUDP;
       }
 
       void OnDisable()
       {
          if ( receiveThread != null) receiveThread.Abort();
          client.Close();
       }
	
	
		// Update is called once per frame
	   void Update () {
		
		
		
	   }
	
		public void test(){
		
		
		}
    }
    // *********************************************************
 