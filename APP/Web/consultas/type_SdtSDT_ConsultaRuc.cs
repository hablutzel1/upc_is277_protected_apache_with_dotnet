/*
				   File: type_SdtSDT_ConsultaRuc
			Description: SDT_ConsultaRuc
				 Author: Nemo 🐠 for C# (.NET) version 17.0.11.163677
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using GeneXus.Programs;
namespace GeneXus.Programs.consultas
{
	[XmlRoot(ElementName="SDT_ConsultaRuc")]
	[XmlType(TypeName="SDT_ConsultaRuc" , Namespace="UPC_ArquitecturaSistemasOP" )]
	[Serializable]
	public class SdtSDT_ConsultaRuc : GxUserType
	{
		public SdtSDT_ConsultaRuc( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ConsultaRuc_Nombre = "";

			gxTv_SdtSDT_ConsultaRuc_Tipodocumento = "";

			gxTv_SdtSDT_ConsultaRuc_Numerodocumento = "";

			gxTv_SdtSDT_ConsultaRuc_Estado = "";

			gxTv_SdtSDT_ConsultaRuc_Condicion = "";

			gxTv_SdtSDT_ConsultaRuc_Direccion = "";

			gxTv_SdtSDT_ConsultaRuc_Ubigeo = "";

			gxTv_SdtSDT_ConsultaRuc_Viatipo = "";

			gxTv_SdtSDT_ConsultaRuc_Vianombre = "";

			gxTv_SdtSDT_ConsultaRuc_Zonacodigo = "";

			gxTv_SdtSDT_ConsultaRuc_Zonatipo = "";

			gxTv_SdtSDT_ConsultaRuc_Numero = "";

			gxTv_SdtSDT_ConsultaRuc_Interior = "";

			gxTv_SdtSDT_ConsultaRuc_Lote = "";

			gxTv_SdtSDT_ConsultaRuc_Dpto = "";

			gxTv_SdtSDT_ConsultaRuc_Manzana = "";

			gxTv_SdtSDT_ConsultaRuc_Kilometro = "";

			gxTv_SdtSDT_ConsultaRuc_Distrito = "";

			gxTv_SdtSDT_ConsultaRuc_Provincia = "";

			gxTv_SdtSDT_ConsultaRuc_Departamento = "";

		}

		public SdtSDT_ConsultaRuc(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("nombre", gxTpr_Nombre, false);


			AddObjectProperty("tipoDocumento", gxTpr_Tipodocumento, false);


			AddObjectProperty("numeroDocumento", gxTpr_Numerodocumento, false);


			AddObjectProperty("estado", gxTpr_Estado, false);


			AddObjectProperty("condicion", gxTpr_Condicion, false);


			AddObjectProperty("direccion", gxTpr_Direccion, false);


			AddObjectProperty("ubigeo", gxTpr_Ubigeo, false);


			AddObjectProperty("viaTipo", gxTpr_Viatipo, false);


			AddObjectProperty("viaNombre", gxTpr_Vianombre, false);


			AddObjectProperty("zonaCodigo", gxTpr_Zonacodigo, false);


			AddObjectProperty("zonaTipo", gxTpr_Zonatipo, false);


			AddObjectProperty("numero", gxTpr_Numero, false);


			AddObjectProperty("interior", gxTpr_Interior, false);


			AddObjectProperty("lote", gxTpr_Lote, false);


			AddObjectProperty("dpto", gxTpr_Dpto, false);


			AddObjectProperty("manzana", gxTpr_Manzana, false);


			AddObjectProperty("kilometro", gxTpr_Kilometro, false);


			AddObjectProperty("distrito", gxTpr_Distrito, false);


			AddObjectProperty("provincia", gxTpr_Provincia, false);


			AddObjectProperty("departamento", gxTpr_Departamento, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="nombre")]
		[XmlElement(ElementName="nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Nombre; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="tipoDocumento")]
		[XmlElement(ElementName="tipoDocumento")]
		public string gxTpr_Tipodocumento
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Tipodocumento; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Tipodocumento = value;
				SetDirty("Tipodocumento");
			}
		}




		[SoapElement(ElementName="numeroDocumento")]
		[XmlElement(ElementName="numeroDocumento")]
		public string gxTpr_Numerodocumento
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Numerodocumento; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Numerodocumento = value;
				SetDirty("Numerodocumento");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Estado; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Estado = value;
				SetDirty("Estado");
			}
		}




		[SoapElement(ElementName="condicion")]
		[XmlElement(ElementName="condicion")]
		public string gxTpr_Condicion
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Condicion; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Condicion = value;
				SetDirty("Condicion");
			}
		}




		[SoapElement(ElementName="direccion")]
		[XmlElement(ElementName="direccion")]
		public string gxTpr_Direccion
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Direccion; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Direccion = value;
				SetDirty("Direccion");
			}
		}




		[SoapElement(ElementName="ubigeo")]
		[XmlElement(ElementName="ubigeo")]
		public string gxTpr_Ubigeo
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Ubigeo; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Ubigeo = value;
				SetDirty("Ubigeo");
			}
		}




		[SoapElement(ElementName="viaTipo")]
		[XmlElement(ElementName="viaTipo")]
		public string gxTpr_Viatipo
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Viatipo; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Viatipo = value;
				SetDirty("Viatipo");
			}
		}




		[SoapElement(ElementName="viaNombre")]
		[XmlElement(ElementName="viaNombre")]
		public string gxTpr_Vianombre
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Vianombre; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Vianombre = value;
				SetDirty("Vianombre");
			}
		}




		[SoapElement(ElementName="zonaCodigo")]
		[XmlElement(ElementName="zonaCodigo")]
		public string gxTpr_Zonacodigo
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Zonacodigo; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Zonacodigo = value;
				SetDirty("Zonacodigo");
			}
		}




		[SoapElement(ElementName="zonaTipo")]
		[XmlElement(ElementName="zonaTipo")]
		public string gxTpr_Zonatipo
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Zonatipo; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Zonatipo = value;
				SetDirty("Zonatipo");
			}
		}




		[SoapElement(ElementName="numero")]
		[XmlElement(ElementName="numero")]
		public string gxTpr_Numero
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Numero; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Numero = value;
				SetDirty("Numero");
			}
		}




		[SoapElement(ElementName="interior")]
		[XmlElement(ElementName="interior")]
		public string gxTpr_Interior
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Interior; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Interior = value;
				SetDirty("Interior");
			}
		}




		[SoapElement(ElementName="lote")]
		[XmlElement(ElementName="lote")]
		public string gxTpr_Lote
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Lote; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Lote = value;
				SetDirty("Lote");
			}
		}




		[SoapElement(ElementName="dpto")]
		[XmlElement(ElementName="dpto")]
		public string gxTpr_Dpto
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Dpto; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Dpto = value;
				SetDirty("Dpto");
			}
		}




		[SoapElement(ElementName="manzana")]
		[XmlElement(ElementName="manzana")]
		public string gxTpr_Manzana
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Manzana; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Manzana = value;
				SetDirty("Manzana");
			}
		}




		[SoapElement(ElementName="kilometro")]
		[XmlElement(ElementName="kilometro")]
		public string gxTpr_Kilometro
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Kilometro; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Kilometro = value;
				SetDirty("Kilometro");
			}
		}




		[SoapElement(ElementName="distrito")]
		[XmlElement(ElementName="distrito")]
		public string gxTpr_Distrito
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Distrito; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Distrito = value;
				SetDirty("Distrito");
			}
		}




		[SoapElement(ElementName="provincia")]
		[XmlElement(ElementName="provincia")]
		public string gxTpr_Provincia
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Provincia; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Provincia = value;
				SetDirty("Provincia");
			}
		}




		[SoapElement(ElementName="departamento")]
		[XmlElement(ElementName="departamento")]
		public string gxTpr_Departamento
		{
			get {
				return gxTv_SdtSDT_ConsultaRuc_Departamento; 
			}
			set {
				gxTv_SdtSDT_ConsultaRuc_Departamento = value;
				SetDirty("Departamento");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDT_ConsultaRuc_Nombre = "";
			gxTv_SdtSDT_ConsultaRuc_Tipodocumento = "";
			gxTv_SdtSDT_ConsultaRuc_Numerodocumento = "";
			gxTv_SdtSDT_ConsultaRuc_Estado = "";
			gxTv_SdtSDT_ConsultaRuc_Condicion = "";
			gxTv_SdtSDT_ConsultaRuc_Direccion = "";
			gxTv_SdtSDT_ConsultaRuc_Ubigeo = "";
			gxTv_SdtSDT_ConsultaRuc_Viatipo = "";
			gxTv_SdtSDT_ConsultaRuc_Vianombre = "";
			gxTv_SdtSDT_ConsultaRuc_Zonacodigo = "";
			gxTv_SdtSDT_ConsultaRuc_Zonatipo = "";
			gxTv_SdtSDT_ConsultaRuc_Numero = "";
			gxTv_SdtSDT_ConsultaRuc_Interior = "";
			gxTv_SdtSDT_ConsultaRuc_Lote = "";
			gxTv_SdtSDT_ConsultaRuc_Dpto = "";
			gxTv_SdtSDT_ConsultaRuc_Manzana = "";
			gxTv_SdtSDT_ConsultaRuc_Kilometro = "";
			gxTv_SdtSDT_ConsultaRuc_Distrito = "";
			gxTv_SdtSDT_ConsultaRuc_Provincia = "";
			gxTv_SdtSDT_ConsultaRuc_Departamento = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ConsultaRuc_Nombre;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Tipodocumento;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Numerodocumento;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Estado;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Condicion;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Direccion;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Ubigeo;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Viatipo;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Vianombre;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Zonacodigo;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Zonatipo;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Numero;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Interior;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Lote;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Dpto;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Manzana;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Kilometro;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Distrito;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Provincia;
		 

		protected string gxTv_SdtSDT_ConsultaRuc_Departamento;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDT_ConsultaRuc", Namespace="UPC_ArquitecturaSistemasOP")]
	public class SdtSDT_ConsultaRuc_RESTInterface : GxGenericCollectionItem<SdtSDT_ConsultaRuc>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ConsultaRuc_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ConsultaRuc_RESTInterface( SdtSDT_ConsultaRuc psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="nombre", Order=0)]
		public  string gxTpr_Nombre
		{
			get { 
				return sdt.gxTpr_Nombre;

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="tipoDocumento", Order=1)]
		public  string gxTpr_Tipodocumento
		{
			get { 
				return sdt.gxTpr_Tipodocumento;

			}
			set { 
				 sdt.gxTpr_Tipodocumento = value;
			}
		}

		[DataMember(Name="numeroDocumento", Order=2)]
		public  string gxTpr_Numerodocumento
		{
			get { 
				return sdt.gxTpr_Numerodocumento;

			}
			set { 
				 sdt.gxTpr_Numerodocumento = value;
			}
		}

		[DataMember(Name="estado", Order=3)]
		public  string gxTpr_Estado
		{
			get { 
				return sdt.gxTpr_Estado;

			}
			set { 
				 sdt.gxTpr_Estado = value;
			}
		}

		[DataMember(Name="condicion", Order=4)]
		public  string gxTpr_Condicion
		{
			get { 
				return sdt.gxTpr_Condicion;

			}
			set { 
				 sdt.gxTpr_Condicion = value;
			}
		}

		[DataMember(Name="direccion", Order=5)]
		public  string gxTpr_Direccion
		{
			get { 
				return sdt.gxTpr_Direccion;

			}
			set { 
				 sdt.gxTpr_Direccion = value;
			}
		}

		[DataMember(Name="ubigeo", Order=6)]
		public  string gxTpr_Ubigeo
		{
			get { 
				return sdt.gxTpr_Ubigeo;

			}
			set { 
				 sdt.gxTpr_Ubigeo = value;
			}
		}

		[DataMember(Name="viaTipo", Order=7)]
		public  string gxTpr_Viatipo
		{
			get { 
				return sdt.gxTpr_Viatipo;

			}
			set { 
				 sdt.gxTpr_Viatipo = value;
			}
		}

		[DataMember(Name="viaNombre", Order=8)]
		public  string gxTpr_Vianombre
		{
			get { 
				return sdt.gxTpr_Vianombre;

			}
			set { 
				 sdt.gxTpr_Vianombre = value;
			}
		}

		[DataMember(Name="zonaCodigo", Order=9)]
		public  string gxTpr_Zonacodigo
		{
			get { 
				return sdt.gxTpr_Zonacodigo;

			}
			set { 
				 sdt.gxTpr_Zonacodigo = value;
			}
		}

		[DataMember(Name="zonaTipo", Order=10)]
		public  string gxTpr_Zonatipo
		{
			get { 
				return sdt.gxTpr_Zonatipo;

			}
			set { 
				 sdt.gxTpr_Zonatipo = value;
			}
		}

		[DataMember(Name="numero", Order=11)]
		public  string gxTpr_Numero
		{
			get { 
				return sdt.gxTpr_Numero;

			}
			set { 
				 sdt.gxTpr_Numero = value;
			}
		}

		[DataMember(Name="interior", Order=12)]
		public  string gxTpr_Interior
		{
			get { 
				return sdt.gxTpr_Interior;

			}
			set { 
				 sdt.gxTpr_Interior = value;
			}
		}

		[DataMember(Name="lote", Order=13)]
		public  string gxTpr_Lote
		{
			get { 
				return sdt.gxTpr_Lote;

			}
			set { 
				 sdt.gxTpr_Lote = value;
			}
		}

		[DataMember(Name="dpto", Order=14)]
		public  string gxTpr_Dpto
		{
			get { 
				return sdt.gxTpr_Dpto;

			}
			set { 
				 sdt.gxTpr_Dpto = value;
			}
		}

		[DataMember(Name="manzana", Order=15)]
		public  string gxTpr_Manzana
		{
			get { 
				return sdt.gxTpr_Manzana;

			}
			set { 
				 sdt.gxTpr_Manzana = value;
			}
		}

		[DataMember(Name="kilometro", Order=16)]
		public  string gxTpr_Kilometro
		{
			get { 
				return sdt.gxTpr_Kilometro;

			}
			set { 
				 sdt.gxTpr_Kilometro = value;
			}
		}

		[DataMember(Name="distrito", Order=17)]
		public  string gxTpr_Distrito
		{
			get { 
				return sdt.gxTpr_Distrito;

			}
			set { 
				 sdt.gxTpr_Distrito = value;
			}
		}

		[DataMember(Name="provincia", Order=18)]
		public  string gxTpr_Provincia
		{
			get { 
				return sdt.gxTpr_Provincia;

			}
			set { 
				 sdt.gxTpr_Provincia = value;
			}
		}

		[DataMember(Name="departamento", Order=19)]
		public  string gxTpr_Departamento
		{
			get { 
				return sdt.gxTpr_Departamento;

			}
			set { 
				 sdt.gxTpr_Departamento = value;
			}
		}


		#endregion

		public SdtSDT_ConsultaRuc sdt
		{
			get { 
				return (SdtSDT_ConsultaRuc)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDT_ConsultaRuc() ;
			}
		}
	}
	#endregion
}