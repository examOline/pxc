﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Teacher_Application : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["questionID"] = "001";
            Session["teacher"] = "李晖";
            Session["teacherID"] = "001";
            Session["courseName"] = "数据库课程设计";
            Session["chapterName"] = "第一章";
            Session["imgFile"] = "";
        }
        lblTeacher.Text = Session["teacher"].ToString();
        lblCourseName.Text = Session["courseName"].ToString();
        txtChapter.Text = Session["chapterName"].ToString();
        txtID.Text = Session["questionID"].ToString(); 
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtContent.Text = "";
        txtAnswer.Text = "";
        //myImg.Src = "";
        //Image1.ImageUrl = "";
        txtContent.Focus();
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        if (fulImg.HasFile)
        //有文件要上传，则将该图片文件以一定的编号规则确定的名称保存在服务器的对应目录中
        {
            string fileName, pathName, extName, extNameCaps;

            //获取文件上传控件中选定的文件的扩展名
            extName = fulImg.FileName;
            int p = extName.LastIndexOf(".");
            extName = extName.Substring(p, extName.Length - p);
            extNameCaps = extName.ToUpper();

            //先获取服务器的物理地址，然后再生成文件存储的路径,
            //文件名的编号规则是：第一个字符's'表示题目类型是'单选题'，后面是题号，要求一题仅对应一张插图
            pathName = Server.MapPath("~/teacher/img/") + Session["teacherID"].ToString() + "\\";

            if (!System.IO.Directory.Exists(pathName))
            {
                //检查目标路径是否存在，如果没有则新建该目录
                //需要注意的是，需要对这个物理路径有足够的权限，否则会报错
                System.IO.Directory.CreateDirectory(pathName);
            }

            fileName = "s" + Session["questionID"].ToString() + extName;
            //Session["imgFile"]=pathName+fileName;
            Session["imgFile"] = pathName + fileName;
            //Image1.ImageUrl = pathName + fileName;
            //Image1.Focus();
            //以下要进行异常处理
            if (extNameCaps == ".JPG" || extNameCaps == ".GIF" || extNameCaps == ".BMP" || extNameCaps == ".PNG")
            {
                fulImg.SaveAs(pathName + fileName);
            }
            else
                Response.Write("<script>alert('附加图片的文件类型不符合要求，请将图片的类型转换成.jpg|.gif|.bmp|.png');location='AddQuestionSC.aspx'</script>");
            //    ValidationSummary1.ShowMessageBox("上传文件的类型不符合系统要求，只能是.jpg.gif.bmp.png");
        }
        //Image1.ImageUrl=Session["imgFile"].ToString();
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        //string isShare = "";
        //if (cbShare.Checked == true)
        //    isShare = "1";
        //else
        //    isShare = "0";
        //string str = "insert into tb_application(questionID,questionText,answer,courseID,teacherID,chapter,share) values('" + Session["questionID"].ToString() + "','" + txtContent.Text.Trim() + "','" + txtAnswer.Text.Trim() + "','" + Session["courseName"].ToString() + "','" + Session["teacherID"].ToString() + "','" + Session["chapterName"].ToString() + "','" + isShare + "')";
        //if (cbID.Checked)
        //{
        //    Session["questionID"] = Int64.Parse(Session["questionID"].ToString()) + 1;
        //    txtID.Text = Session["questionID"].ToString();
        //}
        //else
        //{
        //    txtID.Text = "";
        //}
       

        ////调用公共类的方法，向数据库插入记录
        //BaseClass.OperateData(str);

        //if (fulImg.HasFile)
        ////有文件要上传(可能是用户没有先预览)，则将该图片文件以一定的编号规则确定的名称保存在服务器的对应目录中
        //{
        //    string fileName, pathName, extName, extNameCaps;

        //    //获取文件上传控件中选定的文件的扩展名
        //    extName = fulImg.FileName;
        //    int p = extName.LastIndexOf(".");
        //    extName = extName.Substring(p, extName.Length - p);
        //    extNameCaps = extName.ToUpper();

        //    //先获取服务器的物理地址，然后再生成文件存储的路径,
        //    //文件名的编号规则是：第一个字符's'表示题目类型是'单选题'，后面是题号，要求一题仅对应一张插图
        //    pathName = Server.MapPath("~/teacher/img/") + Session["teacherID"].ToString() + "\\";

        //    if (!System.IO.Directory.Exists(pathName))
        //    {
        //        //检查目标路径是否存在，如果没有则新建该目录
        //        //需要注意的是，需要对这个物理路径有足够的权限，否则会报错
        //        System.IO.Directory.CreateDirectory(pathName);
        //    }

        //    fileName = "s" + Session["questionID"].ToString() + extName;
        //    Session["imgFile"] = "~/teacher/img/" + fileName;
        //    Image1.ImageUrl = "~/teacher/img/" + fileName;
        //    //以下要进行异常处理
        //    if (extNameCaps == ".JPG" || extNameCaps == ".GIF" || extNameCaps == ".BMP" || extNameCaps == ".PNG")
        //    {
        //        fulImg.SaveAs(pathName + fileName);
        //    }
        //    else
        //        Response.Write("<script>alert('附加图片的文件类型不符合要求，请将图片的类型转换成.jpg|.gif|.bmp|.png');location='AddQuestionSC.aspx'</script>");
        //    //    ValidationSummary1.ShowMessageBox("上传文件的类型不符合系统要求，只能是.jpg.gif.bmp.png");
        //}
        //Response.Write("<script>alert('插入成功');</script>");


        //btnCancel_Click(sender, e);
    }
}
