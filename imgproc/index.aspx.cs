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
            
            
            
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/" + filename));
                    Image1.ImageUrl = "~/" + filename;
                }
                catch (Exception ex)
                {
                    Label1.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Composition composition = new Composition();
            var myLayer = new ImageLayer();
            myLayer.SourceFileName = Image1.ImageUrl;
            composition.Layers.Add(myLayer);
            myLayer.Filters.Add(new ColorTintFilter());
            myLayer.Filters.Add(new ResizeFilter { Mode = ResizeMode.UseWidth, Width = SoundInTheory.DynamicImage.Unit.Pixel(1200) });
            myLayer.Filters.Add(new RotationFilter { Angle = 30 });
            string url = ImageUrlGenerator.GetImageUrl(composition);
            myimg.Attributes["src"] = url;
            myimg.Attributes["style"] = "width:500px; height:500px;";
            //   myimg.Attributes["width"] = "200";
         //   myimg.Attributes["height"] = "200";

        }
    }
}