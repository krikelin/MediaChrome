using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Net;
using System.IO;
using System.Threading;
namespace Spirit
{
    [Serializable] 
    public class Spofity
    {
        public delegate void ActionEvent();
        public event ActionEvent BeginLoading;
        public event ActionEvent FinishedLoading;
        private View view;
        public View View
        {
            get
            {
                return view;
            }
            set
            {
                view = value;
            }
        }
        private string uri;
        public string URI
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }
        Stream RawData;
        public void Process()
        {
            WebClient WC = new WebClient();

            Stream D = null;
            if (uri.StartsWith("http://"))
            {
                String F = WC.DownloadString(new Uri(uri));
                D = WC.OpenRead(new Uri(uri));
            }
            else
            {
                D = new FileStream(uri, FileMode.Open, FileAccess.Read);
            }
            RawData=(D);
            

        }
        private int topPos=0;
        public int ITEM_HEIGHT = 20;
        public int LIST_LEFT = 140;	
        public void Serialize()
        {
            if (RawData != null)
            {
                XmlSerializer DS = new XmlSerializer(typeof(View));
                this.View = (View)DS.Deserialize(RawData);
                foreach(Section d in View.Sections)
                {
                	foreach(Element X in d.Elements)
                	{
                		if(X.GetAttribute("position")==("absolute"))
                		{
                			X.Top = int.Parse(X.GetAttribute("top").Replace("@top",topPos.ToString()));
                			X.Left = int.Parse(X.GetAttribute("left"));
                			
                		}
                		else
                		{
                			X.Top = topPos;
                			X.Left = 0;
                		}
                		
                		switch(X.Type)
                		{
                				
                			case "sp:space":
                			
                				topPos+=int.Parse(X.GetAttribute("distance"));
                				
                				break;
                			case "sp:entry":
                				X.Height = ITEM_HEIGHT;
                				if(X.GetAttribute("position")!="absolute")
                				{
                					X.Left = LIST_LEFT;
                					X.Width =-1;
                					X.Top = topPos;
                				}
                			
                				
                				break;
                			case "sp:header":
                				if(X.GetAttribute("position")!="absolute")
                				{
                					X.Left = LIST_LEFT;
                					X.Width =-1;
                					X.Top = topPos;
                				}
                				break;
                			case "sp:label":
                				if(X.GetAttribute("position")!="absolute")
                				{
                					X.Left = LIST_LEFT;
                					X.Width =-1;
                					X.Top = topPos;
                				}
                						break;
                			case "sp:section":
                				X.Height = ITEM_HEIGHT;
                				if(X.GetAttribute("position")!="absolute")
                				{
                				
                					X.Left = LIST_LEFT;
                				}
                				X.Width = -1;
                				break;
                			case "sp:image":
                				X.Width = int.Parse(X.GetAttribute("width"));
                				X.Height = int.Parse(X.GetAttribute("height"));
                				break;
                		}
                		if(X.GetAttribute("position")!="absolute")
                		{
                				topPos+=ITEM_HEIGHT;
                			
                		}
                	}
                }
                if (FinishedLoading != null)
                FinishedLoading();
                RawData = null;
            }
            
        }
        public Thread loadThread;
        public void LoadData()
        {

            if(BeginLoading!=null)
            BeginLoading();
            loadThread = new Thread(Process);
            loadThread.Start();
        }
        public Spofity(string uri)
        {
            this.uri = uri;
            LoadData();

            /*   XmlDocument SR = new XmlDocument();
               SR.Load(uri);   */



        }

        void Spofity_FinishedLoading()
        {

          
        }
    }

    public class UL
    {
        public UL()
        {
            lis = new List<LI>();
        }
        [XmlElement("li")]
        private List<LI> lis;
        public List<LI> Lis
        {
            get
            {
                return lis;
            }
            set
            {
                lis = value;
            }
        }
        public class LI
        {
            public LI()
            {
                lis = new List<LI>();
            }
            [XmlElement("li")]
            private List<LI> lis;
            public List<LI> Lis
            {
                get
                {
                    return lis;
                }
                set
                {
                    lis = value;
                }
            }
        }
    }

    [XmlRoot("html")]
    public class HTML : View
    {


        private List<Section> sections;
        [XmlElement("p")]
        public List<Section> Sections
        {
            get
            {
                return sections;
            }
            set
            {
                sections = value;
            }
        }
    }
    [XmlRoot("view")]
    [Serializable]
    public class View
    {
        public View()
        {
            sections = new List<Section>();
            Sets = new List<Set>();
        }

        private List<Section> sections;
        [XmlElement("section")]
        public List<Section> Sections
        {
            get
            {
                return sections;
            }
            set
            {
                sections = value;
            }
        }
        [XmlElement("set")]
        public List<Set> Sets { get; set; }
    /*    private List<UL> uls;
        public List<UL> Uls
        {
            get
            {
                return uls;
            }
            set
            {
                uls = value;
            }
        }*/
       /* [XmlAttribute("name")]
        public string Name;
        [XmlAttribute("url")]
        public string Url;*/

    }
    public class Section
    {
        public Section()
        {
            elements = new List<Element>();
            Sets = new List<Set>();
        }
        private string name;
        [XmlElement("set")]
        public List<Set> Sets { get; set; }
        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<Element> elements;
        [XmlElement("element")]
        public List<Element> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                elements = value;
            }
        }
    }
    public class Attribute
    {
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("value")]
        public string value;
    }

    public class Set
    {
        [XmlElement("entry")]
        public List<Entry> Entries { get; set; }
        public Set()
        {
            Entries = new List<Entry>();
        }
        [XmlAttribute("image")]
        public string Image { get; set; }
    }

    public class Entry
    {
        [XmlAttribute("href")]
        public string Href { get; set; }
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("artist")]
        public string Artist { get; set; }
    }
    public class Element
    {
    
    	
    	public int Left {get;set;}
    	public int Top {get;set;}
    	
    	public int Width {get;set;}
    	public int Height {get;set;}
        private string data;
        [XmlElement("data")]
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        public Element()
        {
            attributes = new List<Attribute>();
            elements = new List<Element>();
        }
        public bool Selected { get; set; }

        private string type;
        [XmlAttribute("type")]
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        private List<Attribute> attributes;
        [XmlElement("attribute")]
        public List<Attribute> Attributes
        {
            get
            {
                return attributes;
            }
            set
            {
                attributes = value;
            }
        }
        public string GetAttribute(string name)
        {
            foreach (Attribute a in attributes)
            	{
                if (a.name == name)
                {
                    return a.value;
                }
            }
            return "";
        }
        private List<Element> elements;
        [XmlElement("element")]
        public List<Element> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                elements = value;
            }
        }
    }
}
