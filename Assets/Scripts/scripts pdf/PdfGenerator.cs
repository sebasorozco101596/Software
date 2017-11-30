using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;
#if UNITY_EDITOR || UNITY_STANDALONE
using System.Windows.Forms;
#endif


//code by Sammy Haddou - 03/08/2017 - AsteroGames

public class PdfGenerator : MonoBehaviour {


	// Creación de variables globales
	private string pdfName = "Nombre del estudiante (" + System.DateTime.Now.ToString("yyy-MM-dd_HH-mm-ss") + ")";
	private string path = "";
	public Camera mainCam;
	byte[] imageBytes;
	RenderTexture rt;
	//PlayerPrefs a = new PlayerPrefs ();


	public void GeneratePDF () {

		#if UNITY_EDITOR || UNITY_STANDALONE
		// generación del pdf
		SaveFileDialog dlg = new SaveFileDialog();
		dlg.DefaultExt = ".pdf";
		dlg.InitialDirectory = UnityEngine.Application.dataPath;
		dlg.Filter = "Pdf documents (.pdf)|*.pdf";
		dlg.FileName = pdfName;
		//Mensajes de confirmación
		if(dlg.ShowDialog() == DialogResult.OK) {
			path = dlg.FileName;
			print("user have selected a path");
		}
		else if(dlg.ShowDialog() == DialogResult.Cancel || dlg.ShowDialog() == DialogResult.Abort) {
			path = "";
			print("user have closed the windows");
		}

		if(path != "") {
			createPDF(pdfName);
			print("pdf is saved !");
		}
		#endif

	}


	public void createPDF (string fileName) {

		MemoryStream stream = new MemoryStream();

		Document doc = new Document(PageSize.A4);
		PdfWriter pdfWriter = PdfWriter.GetInstance(doc, stream);

		PdfWriter.GetInstance(doc, new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None));


		BaseFont bfHelv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

		iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bfHelv, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
		iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bfHelv, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED);

		doc.Open();
		doc.NewPage();

		PdfPTable mainTable = new PdfPTable(1); //the table of the document
		mainTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER; 
		mainTable.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER; 

		// Titulo
		PdfPCell tmpCell = new PdfPCell(); // a cell for the title
		tmpCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
		tmpCell.BorderWidth = 0;

		tmpCell.AddElement(new Phrase("Reporte del juego"+"\n", fontBold));
		// texto
		tmpCell.AddElement(new Phrase("Las respuestas son:", fontNormal));
		mainTable.AddCell(tmpCell);

		// creacion de la tabla de dos columnas
		PdfPTable tableQuestion = new PdfPTable(3);
		tableQuestion.HorizontalAlignment = Element.ALIGN_CENTER;

		PdfPCell tmpCell3 = new PdfPCell(); // a cell for the normal text
		tmpCell3.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
		tmpCell3.BorderWidth = 0;
		//encabezado de la tabla
		tableQuestion.AddCell(new Phrase("No. pregunta")); 
		tableQuestion.AddCell(new Phrase("Secuencial")); 
		tableQuestion.AddCell(new Phrase("Global")); 
		//imprimiendo respuestas
		for(int i = 0;i < 11; i++){
			tableQuestion.AddCell(new Phrase(""+(i+1)));
			//colocar en la celda 2
			if (PlayerPrefs.GetString ("Type"+(i+1)) == "Secuencial") {
				tableQuestion.AddCell (new Phrase ("" + PlayerPrefs.GetString ("Answer" + (i + 1))));
				tableQuestion.AddCell (new Phrase ("")); 
			//colocar en la celda 3
			} else if (PlayerPrefs.GetString ("Type"+(i+1)) == "Global") {
				tableQuestion.AddCell (new Phrase (""));
				tableQuestion.AddCell (new Phrase ("" + PlayerPrefs.GetString ("Answer" + (i + 1)))); 
			} else {
				tableQuestion.AddCell (new Phrase (""));
				tableQuestion.AddCell (new Phrase (""));
			}
		}

		doc.Add(mainTable);
		doc.Add(tableQuestion);
		doc.Close();

		pdfWriter.Close();
		stream.Close();

		//Done editing the document, we close it and save it.
	}
		

	//used to take a raw screenshot from the app camera view.

	public static Texture2D TakeScreenshot (Camera cam, int width, int height) {

		RenderTexture rt = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
		rt.antiAliasing = 8; //more quality
		cam.targetTexture = rt;
		cam.Render();

		RenderTexture.active = rt;

		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();

		cam.targetTexture = null; //cleaning

		return tex;
	}
		
	/*public void getQuestions(ref PlayerPrefs a){
		this.a = a;
	}
	*/

	//will draw the generated screenshot directly inside the PDF.

	public void AddImageToPDFCell (PdfPCell cell, Texture2D img, float scaleX, float scaleY) {

		imageBytes = img.EncodeToPNG();
		iTextSharp.text.Image finalImage = iTextSharp.text.Image.GetInstance(imageBytes);

		finalImage.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
		finalImage.Border = iTextSharp.text.Rectangle.NO_BORDER;
		finalImage.BorderColor = iTextSharp.text.BaseColor.WHITE;

		finalImage.ScaleToFit(scaleX, scaleY);

		cell.AddElement(finalImage);
	}




}

