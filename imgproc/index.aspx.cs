using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundInTheory.DynamicImage;
using SoundInTheory.DynamicImage.Caching;
using SoundInTheory.DynamicImage.Layers;
using SoundInTheory.DynamicImage.Filters;
using SoundInTheory.DynamicImage.Sources;
using SoundInTheory.DynamicImage.Configuration;
using SoundInTheory.DynamicImage.Util;
using SoundInTheory.DynamicImage.Fluent;
using System.IO;

namespace imgproc
{
    public partial class index : System.Web.UI.Page
    {
        string filename;
        protected void Page_Load(object sender, EventArgs e)
        {

            //CheckBox4.Visible = Label2.Visible = false;
            
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    filename = Path.GetFileName(FileUploadControl.FileName);
                    //FileUploadControl.SaveAs(Server.MapPath("~/" + filename));
                    Image1.ImageUrl = "~/" + filename;
                    Image1.Visible = true;
                    CheckBox1.Visible = CheckBox2.Visible = Image2.Visible = Button1.Visible = Button2.Visible = CheckBox3.Visible = CheckBox4.Visible = Label2.Visible = CheckBox5.Visible= CheckBox6.Visible= true ;
                }
                catch (Exception ex)
                {
                    Label1.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    Label1.Visible = true;
                }

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please select a Image Before Upload";
            }

            Image2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Composition composition = new Composition();
            var myLayer = new ImageLayer();
          

            myLayer.SourceFileName = Image1.ImageUrl;
        
            composition.Layers.Add(myLayer);
            //myLayer.Filters.Add(new ResizeFilter { Mode = ResizeMode.UseWidth, Width = SoundInTheory.DynamicImage.Unit.Pixel(1200) });



            if(CheckBox1.Checked)
            {
                myLayer.Filters.Add(new ColorTintFilter());    
            }
            if(CheckBox2.Checked)
            {

                Image2.Height = int.Parse(TextBox1.Text);
                Image2.Width = int.Parse(TextBox2.Text);
            }
            if(CheckBox3.Checked)
            {

                
                
                if(DropDownList1.SelectedValue.ToString()=="1" )
                {
                    RotationFilter rf = new RotationFilter();
                    rf.Angle = 30;
                    myLayer.Filters.Add(rf);
                }
                else
                {
                    RotationFilter rf = new RotationFilter();
                    rf.Angle = 315;
                    myLayer.Filters.Add(rf);
                }
            }
            if(CheckBox4.Checked)
            {
                myLayer.Filters.Add(new SepiaFilter());
            }
            if (CheckBox5.Checked)
            {
                myLayer.Filters.Add(new EmbossFilter());
            }
            if(CheckBox6.Checked)
            {
                BorderFilter br = new BorderFilter();
                if(DropDownList2.SelectedValue.ToString() =="1")
                {
                    br.Fill.BackgroundColor = Colors.Red;
                }
                if (DropDownList2.SelectedValue.ToString() == "2")
                {
                    br.Fill.BackgroundColor = Colors.Blue;
                }
                if (DropDownList2.SelectedValue.ToString() == "3")
                {
                    br.Fill.BackgroundColor = Colors.Green;
                }
                if (DropDownList2.SelectedValue.ToString() == "4")
                {
                    br.Fill.BackgroundColor = Colors.Black;
                }
                if (DropDownList2.SelectedValue.ToString() == "0")
                {
                    Label7.Visible = true;
                }
                myLayer.Filters.Add(br);
            }
            
           


            
            string url = ImageUrlGenerator.GetImageUrl(composition);
            Image2.ImageUrl = url;
            Image2.Visible = true;
            
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBox2.Checked)
            {
                Label3.Visible = Label4.Visible = true;
                TextBox1.Visible = TextBox2.Visible = true;
            }
            else
            {
                TextBox1.Visible = TextBox2.Visible = false ;
                Label3.Visible = Label4.Visible = false;
            }
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked)
            {
                DropDownList1.Visible = true;
            }
            else
            {
                DropDownList1.Visible = false;
            }
            
        }

        protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBox6.Checked)
            {
                DropDownList2.Visible = true;
            }
            else
            {
                DropDownList2.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList2.SelectedValue.ToString()!="0")
            {
                Label7.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(Image2.ImageUrl);
        }

        
    }
}
