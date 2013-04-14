using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Amnesty_Generator
{
    public partial class Form1 : Form
    {
        Form2 help = null;
        Form3 about = null;
        string saveItem = null;

        int padWidth = 0;
        int padHeight = 0;
        bool margin = false;

        string name = null;
        string width = null;
        string height = null;

        string[] menuMap = {
	        "tagGoogle",
	        "Google Gadgets",
	        "http://www.google.com/ig/directory?synd=open",
	        //
	        "tagNone",
	        "----- More widget libraries:",
	        "http://nil",
	        //
	        "tagArcadeCabin",
	        "ArcadeCabin",
	        "http://www.arcadecabin.com/",
	        //
	        "tagFunny4MySpace",
	        "Funny4MySpace",
	        "http://www.funny4myspace.com/funnies/myspace-funnies.php",
	        //
	        "tagGoodWidgets",
	        "GoodWidgets*",
	        "http://www.goodwidgets.com/widgets/list",
	        //
	        /*{
	        "tagMuseStorm",
	        "MuseStorm",
	        "http://www.musestorm.com/widgets/central.jsp",
	        }",*/
	        "tagPicGames",
	        "PicGames",
	        "http://arcade.picgames.com/",
	        //
	        "tagPoqBum",
	        "POQbum",
	        "http://www.poqbum.com/",
	        //
	        "tagPyzam",
	        "Pyzam",
	        "http://www.pyzam.com/toys.html",
	        //
	        "tagSmackArcade",
	        "SmackArcade",
	        "http://www.smackarcade.com/",
	        //
	        "tagSpringwidgets",
	        "SpringWidgets",
	        "http://www.springwidgets.com/widgets/",
	        //
	        "tagWidgetbox",
	        "Widgetbox",
	        "http://www.widgetbox.com/",
            //
	        "tagYourMinis",
	        "yourminis",
	        "http://www.yourminis.com/minis",
	        //
            "tagNil",
            "",
            "http://nil",
            //
	        "tagNYT",
	        "New York Times*",
	        "http://www.nytimes.com/services/timeswidgets/",
	        //
	        "tagNone",
	        "----- More custom widgets:",
	        "http://nil",
	        //
	        "tag30Boxes",
	        "30 Boxes*",
	        "http://30boxes.com/",
	        //
	        "tagBitty",
	        "Bitty",
	        "http://www.bitty.com/widgets/",
	        //
 	        "tagBlinkx",
	        "Blinkx",
	        "http://blinkx.com/",
            //
	        "tagBoxNet",
	        "Box.net*",
	        "http://www.box.net/",
	        //
	        "tagClockLink",
	        "ClockLink",
	        "http://www.clocklink.com/ENG/gallery.htm",
	        //
	        "tagEBay",
	        "eBay To Go",
	        "http://togo.ebay.com/",
	        //
	        "tagFineTune",
	        "FineTune*",
	        "http://www.finetune.com/",
	        //
	        "tagGrazr",
	        "Grazr",
	        "http://www.grazr.com/config.html",
	        /*{
	        "tagGoogleCalendar",
	        "Google Calendar*",
	        "http://calendar.google.com/",
	        //
	        "tagGoogleMaps",
	        "Google Map Search*",
	        "http://www.google.com/uds/solutions/wizards/mapsearch.html",
	        }",*/
	        "tagImeem",
	        "imeem",
	        "http://www.imeem.com/playlists",
	        //
	        "tagInstaCalc",
	        "instacalc",
	        "http://instacalc.com/",
	        //
	        /*{
	        "tagMyBlogLog",
	        "MyBlogLog*",
	        "http://www.mybloglog.com/",
	        //
	        "tagRockYou",
	        "RockYou*",
	        "http://www.rockyou.com/choose_widget.php",
	        //
	        "tagShelfari",
	        "Shelfari*",
	        "http://www.shelfari.com/",
	        }",*/
	        "tagSlide",
	        "Slide",
	        "http://www.slide.com/arrange",
	        //
            "tagNil",
            "",
            "http://nil",
            //
	        "tagYouTube",
	        "YouTube",
	        "http://www.youtube.com/sharing",
	        //
	        "tagNone",
	        "----- More video widgets:",
	        "http://nil",
	        //
	        "tagAniBoom",
	        "aniBOOM",
	        "http://www.aniboom.com/",
	        //
	        "tagBolt",
	        "Bolt",
	        "http://www.bolt.com/",
	        //
	        "tagClipshack",
	        "ClipShack",
	        "http://www.clipshack.com/",
	        //
	        /*{
	        "tagCruxy",
	        "Cruxy",
	        "https://www.cruxy.com/promote.jsp",
	        }",*/
	        "tagDailyMotion",
	        "Dailymotion",
	        "http://www.dailymotion.com/",
	        //
	        "tagGoogleVideo",
	        "Google Video",
	        "http://video.google.com/",
	        //
	        "tagGuba",
	        "Guba",
	        "http://www.guba.com/",
	        //
	        "tagJumpCut",
	        "Jumpcut",
	        "http://www.jumpcut.com/",
	        //
	        "tagMetaCafe",
	        "Metacafe",
	        "http://www.metacafe.com/",
	        //
	        /*"tagSoapbox",
	        "MSN soapbox*",
	        "http://soapbox.msn.com/",*/
	        //
	        "tagPhotoBucket",
	        "Photobucket",
	        "http://photobucket.com/",
	        //
	        "tagRevver",
	        "Revver",
	        "http://www.revver.com/",
	        //
	        "tagTwango",
	        "Twango",
	        "http://www.twango.com/tools",
	        //
	        "tagVeoh",
	        "Veoh",
	        "http://www.veoh.com/",
	        //
	        "tagVidiac",
	        "Vidiac",
	        "http://www.vidiac.com/",
	        //
	        "tagVidiLife",
	        "vidiLife",
	        "http://www.vidilife.com/",
            //
	        "tagNil",
	        "",
	        "http://nil",
            //
	        "tagNil",
	        "* ",
	        "http://nil",
      };
		
        public Form1()
        {
            InitializeComponent();

            this.CancelButton = button2;
            this.AcceptButton = button3;

            textBox1.LostFocus += new System.EventHandler(this.textBox1_LostFocus);
            textBox1.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);

            menuMap[menuMap.Length - 2] += Amnesty_Generator.Properties.Resources.String1;

            openFileDialog1.Filter = Amnesty_Generator.Properties.Resources.String2 + "|*.gif;*.jpg;*.jpeg;*.png|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg;*.jpeg|PNG (*.png)|*.png";

            foreach (string s in menuMap)
            {
                if (s.StartsWith("tag") == false && s.StartsWith("http:") == false)
                {
                    comboBox1.Items.Add(s);
                }
            }

            comboBox1.Text = (string) comboBox1.Items[0];
        }

        private void Autofill()
        {
            if (textBox1.TextLength == 0)
                button3.Enabled = false;
            else
                button3.Enabled = true;

            padWidth = 0;
            padHeight = 0;
            margin = false;

            name = null;
            width = null;
            height = null;

            string trimmedCode = textBox1.Text.Trim();
            string cleanedCode = trimmedCode.Replace("&amp;", "&");

            if (cleanedCode.Contains("gmodules.com"))
                AutofillGoogle(cleanedCode);
            else if (cleanedCode.Contains("www.arcadecabin.com"))
                AutofillArcadeCabin(cleanedCode);
            else if (cleanedCode.Contains("www.smackarcade.com"))
                AutofillSmackArcade(cleanedCode);
            else if (cleanedCode.Contains("downloads.thespringbox.com") || cleanedCode.Contains("downloads.springwidgets.com"))
                AutofillSpringBox(cleanedCode);
            else if (cleanedCode.Contains("widgetserver.com") || cleanedCode.Contains("widgetbox.com"))
                AutofillWidgetBox(cleanedCode);
            else if (cleanedCode.Contains("www.yourminis.com"))
                AutofillYourMinis(cleanedCode);
            else if (cleanedCode.Contains("nytimes.com"))
                AutofillNYT(cleanedCode);

            else if (cleanedCode.Contains("grazr.com"))
                AutofillGrazr(cleanedCode);
            else if (cleanedCode.Contains("30boxes.com"))
                Autofill30Boxes(cleanedCode);
            else if (cleanedCode.Contains("www.bitty.com"))
                AutofillBitty(cleanedCode);
            else if (cleanedCode.Contains("www.blinkx.com"))
                AutofillBlinkx(cleanedCode);
            else if (cleanedCode.Contains("www.clocklink.com"))
                AutofillClockLink(cleanedCode);
            else if (cleanedCode.Contains("www.finetune.com"))
                AutofillFineTune(cleanedCode);
            else if (cleanedCode.Contains("media.imeem.com"))
                AutofillImeem(cleanedCode);
            else if (cleanedCode.Contains("instacalc.com"))
                AutofillInstacalc(cleanedCode);
            else if (cleanedCode.Contains("www.slide.com"))
                AutofillSlide(cleanedCode);

            else if (cleanedCode.Contains("www.youtube.com"))
                AutofillYouTube(cleanedCode);
            else if (cleanedCode.Contains("www.dailymotion.com"))
                AutofillDailyMotion(cleanedCode);
            else if (cleanedCode.Contains("video.google.com"))
                AutofillGoogleVideo(cleanedCode);
            else if (cleanedCode.Contains("soapbox.msn.com"))
                AutofillSoapBox(cleanedCode);

            // flash support (video)
            else if (cleanedCode.Contains("api.aniboom.com"))
                AutofillFlash(cleanedCode, "aniBOOM", "videoar=", "&");
            else if (cleanedCode.Contains("www.bolt.com"))
            {
                AutofillFlash(cleanedCode, "Bolt", "contentId=", "&");
                padHeight = 28;
            }
            else if (cleanedCode.Contains("www.clipshack.com"))
                AutofillFlash(cleanedCode, "ClipShack", "key=", "&");
            else if (cleanedCode.Contains("www.guba.com"))
                AutofillFlash(cleanedCode, "Guba", "src=\"", "\"");
            else if (cleanedCode.Contains("www.jumpcut.com"))
                AutofillFlash(cleanedCode, "Jumpcut", "asset_id=", "&");
            else if (cleanedCode.Contains("www.metacafe.com"))
            {
                AutofillFlash(cleanedCode, "Metacafe", null, null);
                padHeight = 28;
            }
            else if (cleanedCode.Contains("photobucket.com"))
                AutofillFlash(cleanedCode, "Photobucket", "src=\"", "\"");
            else if (cleanedCode.Contains("flash.revver.com"))
                AutofillFlash(cleanedCode, "Revver", "mediaId:", ";");
            else if (cleanedCode.Contains("www.twango.com"))
                AutofillFlash(cleanedCode, "Twango", "", "");
            else if (cleanedCode.Contains("www.veoh.com"))
                AutofillFlash(cleanedCode, "Veoh", "permalinkId=", "&");
            else if (cleanedCode.Contains("www.vidiac.com"))
                AutofillFlash(cleanedCode, "Vidiac", "video=", "&");
            else if (cleanedCode.Contains("www.vidiLife.com"))
            {
                AutofillFlash(cleanedCode, "vidiLife", "cryp=", "'");
                padHeight = 20;
            }

            // flash support (other)
            else if (cleanedCode.Contains("www.box.net/static/flash/widget_player.swf"))
                AutofillFlash(cleanedCode, "Box.net*", "folderId=", ",");
            else if (cleanedCode.Contains("www.box.net/static/flash/box_explorer.swf"))
                AutofillFlash(cleanedCode, "Box.net*", "widgetHash=", "&");
            else if (cleanedCode.Contains("funny4myspace.com"))
            {
                AutofillFlash(cleanedCode, "Funny4MySpace", null, null);
                padHeight = 28;
            }
            else if (cleanedCode.Contains("goodwidgets.com"))
                AutofillFlash(cleanedCode, "GoodWidgets*", null, null);
            //else if (cleanedCode.Contains("http://www.miniclip.com"))
            //    AutofillFlash(cleanedCode, "MiniClip", "yyy", "zzz");
            else if (cleanedCode.Contains("arcade.picgames.com"))
                AutofillFlash(cleanedCode, "PicGames", null, null);
            else if (cleanedCode.Contains("www.poqbum.com"))
            {
                AutofillFlash(cleanedCode, "POQbum", null, null);
                padHeight = 56;
            }
            else if (cleanedCode.Contains("www.pyzam.com"))
            {
                AutofillFlash(cleanedCode, "Pyzam", null, null);
                padHeight = 56;
            }
            else if (cleanedCode.Contains("togo.ebay.com"))
            {
                AutofillFlash(cleanedCode, "eBay To Go", null, null);
             }

            // hidden support
            else if (cleanedCode.Contains("services.brightcove.com"))
                AutofillFlash(cleanedCode, "brightcove", "videoID=", "&");
            else if (cleanedCode.Contains("channelfrederator.com"))
                AutofillFlash(cleanedCode, "Channel Frederator", null, null);
            else if (cleanedCode.Contains("widgets.clearspring.com"))
                AutofillFlash(cleanedCode, "Clearspring", "id=\"", "\"");
            else if (cleanedCode.Contains("www.cruxy.com"))
                AutofillFlash(cleanedCode, "cruxy", "", "");
            else if (cleanedCode.Contains("www.dappit.com"))
            {
                AutofillFlash(cleanedCode, "Dapper", "src=\"", "\"");
                padHeight = 82;
            }
            else if (cleanedCode.Contains("flixfocus.com"))
                AutofillFlash(cleanedCode, "FlixFocus", "pg=", "&");
            else if (cleanedCode.Contains("podtech.net"))
                AutofillFlash(cleanedCode, "PodTech.net", "bc=", "&");
            else if (cleanedCode.Contains("web.splashcast.net"))
                AutofillFlash(cleanedCode, "SplashCast", null, null);
            else if (cleanedCode.Contains("www.vimeo.com"))
                AutofillFlash(cleanedCode, "Vimeo", "clip_id=", "&");

            else if (cleanedCode.Contains(".swf"))
                AutofillFlash(cleanedCode, null, null, null);

            // kludge: if there is no drag area in Sidebar, the gadget controls disappear!
            if (padHeight == 0)
                padHeight = 1;

            if (name != null && textBox2.TextLength == 0)
            {
                try
                {
                    textBox2.Text = Uri.UnescapeDataString(name);
                }

                catch
                {
                }
            }

            int wvalue = 0;

            if (width != null)
            {
                try
                {
                    wvalue = Int32.Parse(width);
                }

                catch
                {
                }
            }

            int hvalue = 0;

            if (height != null)
            {
                try
                {
                    hvalue = Int32.Parse(height);
                }

                catch
                {
                }
            }

            if (width != null && textBox4.TextLength == 0)
            {
                try
                {
                    if (width.EndsWith("%") && hvalue > 0)
                    {
                        string twidth = width.Remove(width.Length - 1, 1);
                        wvalue = Int32.Parse(twidth);
                        wvalue = (hvalue * wvalue) / 100;
                    }
                    else if (width.Contains("."))
                    {
                        int index = width.IndexOf(".");
                        string iwidth = width.Substring(0, index);
                        wvalue = Int32.Parse(iwidth);
                    }

                    if(wvalue > 0)
                        textBox4.Text = String.Format("{0}", wvalue);
                }

                catch
                {
                }
            }

            if (height != null && textBox5.TextLength == 0)
            {
                try
                {
                    if (height.EndsWith("%") && wvalue > 0)
                    {
                        string theight = height.Remove(height.Length - 1, 1);
                        hvalue = Int32.Parse(theight);
                        hvalue = (wvalue * hvalue) / 100;
                    }
                    else if (height.Contains("."))
                    {
                        int index = height.IndexOf(".");
                        string iheight = height.Substring(0, index);
                        hvalue = Int32.Parse(iheight);
                    }

                    if (hvalue > 0)
                        textBox5.Text = String.Format("{0}", hvalue);
                }

                catch
                {
                }
            }
        }

        // widget libraries
        private void AutofillGoogle(string s)
        {
            string iname = GetAttribute(s, "&title=", "&");
            name = iname.Replace("+", " ");

            width = GetAttribute(s, "&w=", "&");
            height = GetAttribute(s, "&h=", "&");
  
            if (s.Contains("&border=%23ffffff%7C3px"))
            {
                padHeight = 56;
                padWidth = 16;
            }
            else
            {
                padHeight = 50;
                padWidth = 10;
            }

            comboBox1.Text = "Google Gadgets";
        }

        private void AutofillArcadeCabin(string s)
        {
            name = GetAttribute(s, "/tempswf/", "\"");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            padHeight = 28;

            comboBox1.Text = "ArcadeCabin";
        }

        private void AutofillSmackArcade(string s)
        {
            name = GetAttribute(s, "/play/", "\"");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            padHeight = 42;

            comboBox1.Text = "SmackArcade";
        }

        private void AutofillSpringBox(string s)
        {
            name = GetReverseAttribute(s, ".sbw", "=");

            width = GetAttribute(s, "width=\"", "\"");
            if(width.Equals("1"))
                width = GetNextAttribute(s, "width=\"", "\"");

            if(width.Equals(""))
                width = GetAttribute(s, "width:", "px");

            height = GetAttribute(s, "height=\"", "\"");
            if (height.Equals("1"))
                height = GetNextAttribute(s, "height=\"", "\"");

            if (height.Equals(""))
                height = GetAttribute(s, "height:", "px");

 
            comboBox1.Text = "SpringWidgets";
        }

        private void AutofillWidgetBox(string s)
        {
            if (s.Contains("appId="))
            {
                name = "Widgetbox " + GetAttribute(s, "appId=", "\"");
                width = GetAttribute(s, "width=\"", "px");
                height = GetAttribute(s, "height=\"", "px");
            }
            else
            {
                name = "Widgetbox " + GetAttribute(s, "panelId=", "\"");
            }
 
            comboBox1.Text = "Widgetbox";
        }

        private void AutofillYourMinis(string s)
        {
            name = GetAttribute(s, "mini:", "\"");

            width = GetAttribute(s, "width=\"", "\"");
            if (width.Equals("100%"))
                width = GetNextAttribute(s, "width=\"", "\"");

            height = GetAttribute(s, "height=\"", "\"");
            if (height.Equals("100%"))
                height = GetNextAttribute(s, "height=\"", "\"");

            padHeight = 56;

            comboBox1.Text = "YourMinis";
        }

        private void AutofillNYT(string s)
        {
            name = "New York Times" + String.Format(" {0}", s.GetHashCode());
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            if (width.Equals("100%"))
                width = height;

            comboBox1.Text = "New York Times*";
        }

        // custom widgets
        private void AutofillGrazr(string s)
        {
            name = "Grazr" + String.Format(" {0}", s.GetHashCode());
            width = GetAttribute(s, "width:", "px");
            height = GetAttribute(s, "height:", "px");

            comboBox1.Text = "Grazr";
        }

        private void Autofill30Boxes(string s)
        {
            name = "30 Boxes " + GetAttribute(s, "src=\"", "\"");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            comboBox1.Text = "30 Boxes*";
        }

        private void AutofillBitty(string s)
        {
            name = "Bitty" + String.Format(" {0}", s.GetHashCode());
            width = GetAttribute(s, "width: \"", "\"");
            height = GetAttribute(s, "height: \"", "\"");

            comboBox1.Text = "Bitty";
        }

        private void AutofillBlinkx(string s)
        {
            name = "Blinkx" + String.Format(" {0}", s.GetHashCode());
            width = GetAttribute(s, "width='", "'");
            height = GetAttribute(s, "height='", "'");

            comboBox1.Text = "Blinkx";
        }

        private void AutofillClockLink(string s)
        {
            name = GetReverseAttribute(s, ".swf", "\"");
            width = GetAttribute(s, "width = ", ";");
            height = GetAttribute(s, "height = ", ";");

            comboBox1.Text = "ClockLink";
        }

        private void AutofillFineTune(string s)
        {
            name = "FineTune " + GetAttribute(s, "pinst=\"", "\"");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            comboBox1.Text = "FineTune*";
        }

        private void AutofillImeem(string s)
        {
            if(s.Contains("/pl/")) {
                name = "imeem " + GetAttribute(s, "/pl/", "/");
                width = GetAttribute(s, "width=\"", "\"");
                height = GetAttribute(s, "height=\"", "\"");
 
                comboBox1.Text = "imeem";
            }
            else if(s.Contains("/v/")) {
                name = "imeem " + GetAttribute(s, "/v/", "/");
                width = GetAttribute(s, "width=\"", "\"");
                height = GetAttribute(s, "height=\"", "\"");
 
                comboBox1.Text = "imeem";
           }
        }

        private void AutofillInstacalc(string s)
        {
            name = "instacalc " + String.Format(" {0}", s.GetHashCode());
            width = GetAttribute(s, "instacalc_embed_width = ", ";");
            height = GetAttribute(s, "instacalc_embed_height = ", ";");

            comboBox1.Text = "instacalc";
        }

        private void AutofillSlide(string s)
        {
            name = "Slide " + GetAttribute(s, "channel=\"", "&");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            padHeight = 23;

            comboBox1.Text = "Slide";
        }

        // video widgets
        private void AutofillYouTube(string s)
        {
            name = GetAttribute(s, "/v/", "\"");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            comboBox1.Text = "YouTube";
        }

        private void AutofillDailyMotion(string s)
        {
            name = GetAttribute(s, "/video/", "\"");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            padHeight = 42;

            comboBox1.Text = "Dailymotion";
        }

        private void AutofillGoogleVideo(string s)
        {
            name = "Google Video " + GetAttribute(s, "docId=", "&");
            width = GetAttribute(s, "width:", "px");
            height = GetAttribute(s, "height:", "px");

            comboBox1.Text = "Google Video";
        }

        private void AutofillSoapBox(string s)
        {
            name = GetAttribute(s, "title=\"", "\"");
            width = GetAttribute(s, "width=\"", "\"");
            height = GetAttribute(s, "height=\"", "\"");

            padHeight = 28;

            comboBox1.Text = "MSN soapbox*";
        }

        private void AutofillFlash(string s, string site, string pre, string post)
        {
            if(site != null || s.StartsWith("<object ") || s.StartsWith("<embed ")){
                if (pre == null && post == null && s.Contains(".swf"))
                    name = GetReverseAttribute(s, ".swf", "/");

                if (name == null || name.Length == 0)
                {
                    string hash = null;

                    if (pre != null && post != null && pre.Length > 0 && post.Length > 0)
                        hash = GetAttribute(s, pre, post);

                    if (hash == null)
                    {
                        if (site == null)
                            name = "Flash" + String.Format(" {0}", s.GetHashCode());
                        else
                            name = site + String.Format(" {0}", s.GetHashCode());
                    }
                    else
                    {
                        if (site == null)
                            name = "Flash " + hash;
                        else
                            name = site + " " + hash;
                    }
                }

                width = GetAttribute(s, "width=\"", "\"");
                if(width == null)
                    width = GetAttribute(s, "width='", "'");
                if(width == null)
                    width = GetAttribute(s, "width:", ";");
 
                height = GetAttribute(s, "height=\"", "\"");
                if(height == null)
                    height = GetAttribute(s, "height='", "'");
                if(height == null)
                    height = GetAttribute(s, "height:", ";");
 
                if(site != null)
                    comboBox1.Text = site;
            }
        }

        private string GetReverseAttribute(string s, string pre, string post)
        {
            int start = s.IndexOf(pre);
            if (start > 0)
            {
                int end = s.LastIndexOf(post, start);

                if (end > 0)
                {
                    end++;
                    return s.Substring(end, start - end);
                }
            }

            return null;
        }

        private string GetAttribute(string s, string pre, string post)
        {
            int start = s.IndexOf(pre);
            if (start > 0)
            {
                start += pre.Length;
                int end = s.IndexOf(post, start);

                if (end > 0 && end > start)
                    return s.Substring(start, end - start);
            }

            return "";
        }

        private string GetNextAttribute(string s, string pre, string post)
        {
            int start = s.IndexOf(pre);
            if (start > 0)
            {
                start += pre.Length;

                start = s.IndexOf(pre, start);
                if (start > 0)
                {
                    start += pre.Length;
                    int end = s.IndexOf(post, start);

                    if (end > 0 && end > start)
                        return s.Substring(start, end - start);
                }
            }

            return null;
        }

        private void Generate()
        {
            int width = 0;
            int height = 0;

            try
            {
                width = Int32.Parse(textBox4.Text) + padWidth;
                height = Int32.Parse(textBox5.Text) + padHeight;
            }

            catch
            {
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }

            string d = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string d2 = Path.Combine(d, "Microsoft");
            string d3 = Path.Combine(d2, "Windows Sidebar");
            string d4 = Path.Combine(d3, "Gadgets");

            if (Directory.Exists(d4) == false)
            {
                d = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                d2 = Path.Combine(d, "Microsoft");
                d3 = Path.Combine(d2, "Windows Sidebar");
                d4 = Path.Combine(d3, "Gadgets");
            }

            string folder = textBox2.Text + ".gadget";
            string target = Path.Combine(d4, folder);

            if (Directory.Exists(target))
            {
                String name = String.Format("\"{0}\"", textBox2.Text);
                String msg = String.Format(Amnesty_Generator.Properties.Resources.String3, name);
                DialogResult dr = MessageBox.Show(msg, "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Directory.Delete(target, true);
                    System.Threading.Thread.Sleep(250);
                }
                else
                    return;
            }

            DirectoryInfo di = Directory.CreateDirectory(target);
            if (di.Exists == true)
            {
                Bitmap frontImage = Amnesty_Generator.Properties.Resources.gfront;
                frontImage.Save(Path.Combine(target, "front.png"));

                Bitmap logoImage = Amnesty_Generator.Properties.Resources.glogo;
                logoImage.Save(Path.Combine(target, "logo.png"));

                if (pictureBox1.Image == null)
                {
                    Bitmap iconImage = Amnesty_Generator.Properties.Resources.gicon;
                    iconImage.Save(Path.Combine(target, "icon.png"));
                }
                else {
                    try {
                        pictureBox1.Image.Save(Path.Combine(target, "icon.png"));
                    }

                    catch
                    {
                        Bitmap iconImage = Amnesty_Generator.Properties.Resources.gicon;
                        iconImage.Save(Path.Combine(target, "icon.png"));
                    }
                }

                string js = Amnesty_Generator.Properties.Resources.gjs;
                File.WriteAllText(Path.Combine(target, "generator.js"), js);

                string css = Amnesty_Generator.Properties.Resources.gcss;
                string css2 = css.Replace("320", String.Format("{0}", width));
                string css3 = css2.Replace("240", String.Format("{0}", height));
                File.WriteAllText(Path.Combine(target, "generator.css"), css3);

                string code = textBox1.Text;
                if (code.Contains("http://gmodules.com") && code.Contains("synd=open"))
                {
                    code = code.Replace("synd=open", "synd=amnesty");
                }

                string htm = Amnesty_Generator.Properties.Resources.ghtm;
                string htm2 = htm.Replace("</div>", code + "</div>");
                File.WriteAllText(Path.Combine(target, "generator.htm"), htm2);

                string e1 = textBox2.Text.Replace("&", "&amp;");
                string e2 = e1.Replace("<", "&lt;");
                string ename = e2.Replace(">", "&gt;");

                string xml = Amnesty_Generator.Properties.Resources.gxml;
                string xml2 = xml.Replace("Generator</name>", ename + "</name>");
                string xml3 = xml2.Replace("Generator</namespace>", ename + "</namespace>");
                File.WriteAllText(Path.Combine(target, "gadget.xml"), xml3);

                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox1.Text = "";
                comboBox1.Focus();

                {

                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = "sidebar.exe";
                    p.Start();

                    System.Threading.Thread.Sleep(250);

                    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                    System.Windows.Forms.SendKeys.SendWait("{ESC}");

                    System.Threading.Thread.Sleep(250);
                }

                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = "sidebar.exe";
                    p.Start();

                    System.Threading.Thread.Sleep(250);

                    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                }

                // Application.ExitThread();
            }
         }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = -1;
            foreach (string s in menuMap)
            {
                i++;
                if (s.Equals(comboBox1.Text))
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.Verb = "open";
                    p.StartInfo.FileName = menuMap[i + 1];
                    p.Start();
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // browse for image
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                pictureBox1.Load(openFileDialog1.FileName);
           }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                textBox2.Focus();
            }
            else if (textBox4.TextLength == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                textBox4.Focus();
            }
            else if (textBox5.TextLength == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                textBox5.Focus();
            }
            else
                Generate();
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            Autofill();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Autofill();
                textBox2.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            if (selected.Equals("") || selected.EndsWith(":") || selected.StartsWith("*"))
            {
                comboBox1.Text = saveItem;
            }
            else
            {
                if (saveItem != null && saveItem.Equals(selected) == false)
                {
                    int i = -1;
                    foreach (string s in menuMap)
                    {
                        i++;
                        if (s.Equals(selected))
                        {
                            string helpString = menuMap[i - 1];
                            if (
                                helpString.Equals("tagYourMinis") ||
                                helpString.Equals("tagWidgetbox") ||
                                helpString.Equals("tagBoxNet") ||
                                helpString.Equals("tagImeem") ||
                                helpString.Equals("tagTwango")
                            )
                                helpString = "tagMissing";
                        

                            if (help == null)
                            {
                                help = new Form2(helpString);
                                help.SetDesktopLocation(this.Location.X - 256, this.Location.Y);
                            }
                            else
                                help.ShowHelp(helpString);

                            break;
                        }
                    }
                    
                }

                saveItem = selected;
            }
        }

        private void amnestyGeneratorHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (help == null)
            {
                help = new Form2("tagGoogle");
                help.SetDesktopLocation(this.Location.X - 256, this.Location.Y);
            }

            help.Visible = true;
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest) System.Net.WebRequest.Create("http://www.amnestywidgets.com/updates/generator_win.xml");
            req.UserAgent = "Amnesty Generator/1.5 (Windows)";
            req.Timeout = 10000;

            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse) req.GetResponse();
            StreamReader stream = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
            string xml = stream.ReadToEnd();
 
            res.Close();
            stream.Close();

            Cursor = Cursors.Arrow;

            if (xml != null)
            {
                int start = xml.IndexOf("<version>");
                if (start > 0)
                {
                    start += 9;
                    int end = xml.IndexOf("</version>", start);
                    if (end > start)
                    {
                        string v = xml.Substring(start, end - start);
                        int version = 0;

                        try
                        {
                            version = Int32.Parse(v);
                            if(version > 150)
                            {
                                DialogResult dr = MessageBox.Show(Amnesty_Generator.Properties.Resources.String4, "", MessageBoxButtons.YesNo);
                                if (dr == DialogResult.Yes)
                                {
                                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                                    p.StartInfo.Verb = "open";
                                    p.StartInfo.FileName = "http://www.amnestywidgets.com/updates/generator_win.htm";
                                    p.Start();
                                }
                            }
                            else
                                MessageBox.Show(Amnesty_Generator.Properties.Resources.String5);
                        }

                        catch
                        {
                        }
                    }
                }
            }
        }

        private void mesaDynamicsOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.Verb = "open";
            p.StartInfo.FileName = "http://www.amnestywidgets.com";
            p.Start();
        }

        private void contactCustomerSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.Verb = "open";
            p.StartInfo.FileName = "mailto:support@mesadynamics.com?subject=Amnesty%20Generator%20Vista";
            p.Start();
        }

        private void aboutAmnestyGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (about == null)
                about = new Form3();

            about.Visible = true;
        }
    }
}