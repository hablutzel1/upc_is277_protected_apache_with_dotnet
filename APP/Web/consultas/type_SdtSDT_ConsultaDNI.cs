/*
				   File: type_SdtSDT_ConsultaDNI
			Description: SDT_ConsultaDNI
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
	[XmlRoot(ElementName="SDT_ConsultaDNI")]
	[XmlType(TypeName="SDT_ConsultaDNI" , Namespace="UPC_ArquitecturaSistemasOP" )]
	[Serializable]
	public class SdtSDT_ConsultaDNI : GxUserType
	{
		public SdtSDT_ConsultaDNI( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ConsultaDNI_Nombre = "";

			gxTv_SdtSDT_ConsultaDNI_Tipodocumento = "";

			gxTv_SdtSDT_ConsultaDNI_Numerodocumento = "";

			gxTv_SdtSDT_ConsultaDNI_Estado = "";

			gxTv_SdtSDT_ConsultaDNI_Condicion = "";

			gxTv_SdtSDT_ConsultaDNI_Direccion = "";

			gxTv_SdtSDT_ConsultaDNI_Ubigeo = "";

			gxTv_SdtSDT_ConsultaDNI_Viatipo = "";

			gxTv_SdtSDT_ConsultaDNI_Vianombre = "";

			gxTv_SdtSDT_ConsultaDNI_Zonacodigo = "";

			gxTv_SdtSDT_ConsultaDNI_Zonatipo = "";

			gxTv_SdtSDT_ConsultaDNI_Numero = "";

			gxTv_SdtSDT_ConsultaDNI_Interior = "";

			gxTv_SdtSDT_ConsultaDNI_Lote = "";

			gxTv_SdtSDT_ConsultaDNI_Dpto = "";

			gxTv_SdtSDT_ConsultaDNI_Manzana = "";

			gxTv_SdtSDT_ConsultaDNI_Kilometro = "";

			gxTv_SdtSDT_ConsultaDNI_Distrito = "";

			gxTv_SdtSDT_ConsultaDNI_Provincia = "";

			gxTv_SdtSDT_ConsultaDNI_Departamento = "";

			gxTv_SdtSDT_ConsultaDNI_Apellidopaterno = "";

			gxTv_SdtSDT_ConsultaDNI_Apellidomaterno = "";

			gxTv_SdtSDT_ConsultaDNI_Nombres = "";

		}

		public SdtSDT_ConsultaDNI(IGxContext context)
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


			AddObjectProperty("apellidoPaterno", gxTpr_Apellidopaterno, false);


			AddObjectProperty("apellidoMaterno", gxTpr_Apellidomaterno, false);


			AddObjectProperty("nombres", gxTpr_Nombres, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="nombre")]
		[XmlElement(ElementName="nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Nombre; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="tipoDocumento")]
		[XmlElement(ElementName="tipoDocumento")]
		public string gxTpr_Tipodocumento
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Tipodocumento; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Tipodocumento = value;
				SetDirty("Tipodocumento");
			}
		}




		[SoapElement(ElementName="numeroDocumento")]
		[XmlElement(ElementName="numeroDocumento")]
		public string gxTpr_Numerodocumento
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Numerodocumento; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Numerodocumento = value;
				SetDirty("Numerodocumento");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Estado; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Estado = value;
				SetDirty("Estado");
			}
		}




		[SoapElement(ElementName="condicion")]
		[XmlElement(ElementName="condicion")]
		public string gxTpr_Condicion
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Condicion; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Condicion = value;
				SetDirty("Condicion");
			}
		}




		[SoapElement(ElementName="direccion")]
		[XmlElement(ElementName="direccion")]
		public string gxTpr_Direccion
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Direccion; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Direccion = value;
				SetDirty("Direccion");
			}
		}




		[SoapElement(ElementName="ubigeo")]
		[XmlElement(ElementName="ubigeo")]
		public string gxTpr_Ubigeo
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Ubigeo; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Ubigeo = value;
				SetDirty("Ubigeo");
			}
		}




		[SoapElement(ElementName="viaTipo")]
		[XmlElement(ElementName="viaTipo")]
		public string gxTpr_Viatipo
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Viatipo; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Viatipo = value;
				SetDirty("Viatipo");
			}
		}




		[SoapElement(ElementName="viaNombre")]
		[XmlElement(ElementName="viaNombre")]
		public string gxTpr_Vianombre
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Vianombre; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Vianombre = value;
				SetDirty("Vianombre");
			}
		}




		[SoapElement(ElementName="zonaCodigo")]
		[XmlElement(ElementName="zonaCodigo")]
		public string gxTpr_Zonacodigo
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Zonacodigo; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Zonacodigo = value;
				SetDirty("Zonacodigo");
			}
		}




		[SoapElement(ElementName="zonaTipo")]
		[XmlElement(ElementName="zonaTipo")]
		public string gxTpr_Zonatipo
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Zonatipo; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Zonatipo = value;
				SetDirty("Zonatipo");
			}
		}




		[SoapElement(ElementName="numero")]
		[XmlElement(ElementName="numero")]
		public string gxTpr_Numero
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Numero; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Numero = value;
				SetDirty("Numero");
			}
		}




		[SoapElement(ElementName="interior")]
		[XmlElement(ElementName="interior")]
		public string gxTpr_Interior
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Interior; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Interior = value;
				SetDirty("Interior");
			}
		}




		[SoapElement(ElementName="lote")]
		[XmlElement(ElementName="lote")]
		public string gxTpr_Lote
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Lote; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Lote = value;
				SetDirty("Lote");
			}
		}




		[SoapElement(ElementName="dpto")]
		[XmlElement(ElementName="dpto")]
		public string gxTpr_Dpto
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Dpto; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Dpto = value;
				SetDirty("Dpto");
			}
		}




		[SoapElement(ElementName="manzana")]
		[XmlElement(ElementName="manzana")]
		public string gxTpr_Manzana
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Manzana; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Manzana = value;
				SetDirty("Manzana");
			}
		}




		[SoapElement(ElementName="kilometro")]
		[XmlElement(ElementName="kilometro")]
		public string gxTpr_Kilometro
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Kilometro; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Kilometro = value;
				SetDirty("Kilometro");
			}
		}




		[SoapElement(ElementName="distrito")]
		[XmlElement(ElementName="distrito")]
		public string gxTpr_Distrito
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Distrito; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Distrito = value;
				SetDirty("Distrito");
			}
		}




		[SoapElement(ElementName="provincia")]
		[XmlElement(ElementName="provincia")]
		public string gxTpr_Provincia
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Provincia; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Provincia = value;
				SetDirty("Provincia");
			}
		}




		[SoapElement(ElementName="departamento")]
		[XmlElement(ElementName="departamento")]
		public string gxTpr_Departamento
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Departamento; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Departamento = value;
				SetDirty("Departamento");
			}
		}




		[SoapElement(ElementName="apellidoPaterno")]
		[XmlElement(ElementName="apellidoPaterno")]
		public string gxTpr_Apellidopaterno
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Apellidopaterno; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Apellidopaterno = value;
				SetDirty("Apellidopaterno");
			}
		}




		[SoapElement(ElementName="apellidoMaterno")]
		[XmlElement(ElementName="apellidoMaterno")]
		public string gxTpr_Apellidomaterno
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Apellidomaterno; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Apellidomaterno = value;
				SetDirty("Apellidomaterno");
			}
		}




		[SoapElement(ElementName="nombres")]
		[XmlElement(ElementName="nombres")]
		public string gxTpr_Nombres
		{
			get {
				return gxTv_SdtSDT_ConsultaDNI_Nombres; 
			}
			set {
				gxTv_SdtSDT_ConsultaDNI_Nombres = value;
				SetDirty("Nombres");
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
			gxTv_SdtSDT_ConsultaDNI_Nombre = "";
			gxTv_SdtSDT_ConsultaDNI_Tipodocumento = "";
			gxTv_SdtSDT_ConsultaDNI_Numerodocumento = "";
			gxTv_SdtSDT_ConsultaDNI_Estado = "";
			gxTv_SdtSDT_ConsultaDNI_Condicion = "";
			gxTv_SdtSDT_ConsultaDNI_Direccion = "";
			gxTv_SdtSDT_ConsultaDNI_Ubigeo = "";
			gxTv_SdtSDT_ConsultaDNI_Viatipo = "";
			gxTv_SdtSDT_ConsultaDNI_Vianombre = "";
			gxTv_SdtSDT_ConsultaDNI_Zonacodigo = "";
			gxTv_SdtSDT_ConsultaDNI_Zonatipo = "";
			gxTv_SdtSDT_ConsultaDNI_Numero = "";
			gxTv_SdtSDT_ConsultaDNI_Interior = "";
			gxTv_SdtSDT_ConsultaDNI_Lote = "";
			gxTv_SdtSDT_ConsultaDNI_Dpto = "";
			gxTv_SdtSDT_ConsultaDNI_Manzana = "";
			gxTv_SdtSDT_ConsultaDNI_Kilometro = "";
			gxTv_SdtSDT_ConsultaDNI_Distrito = "";
			gxTv_SdtSDT_ConsultaDNI_Provincia = "";
			gxTv_SdtSDT_ConsultaDNI_Departamento = "";
			gxTv_SdtSDT_ConsultaDNI_Apellidopaterno = "";
			gxTv_SdtSDT_ConsultaDNI_Apellidomaterno = "";
			gxTv_SdtSDT_ConsultaDNI_Nombres = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ConsultaDNI_Nombre;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Tipodocumento;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Numerodocumento;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Estado;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Condicion;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Direccion;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Ubigeo;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Viatipo;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Vianombre;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Zonacodigo;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Zonatipo;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Numero;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Interior;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Lote;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Dpto;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Manzana;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Kilometro;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Distrito;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Provincia;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Departamento;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Apellidopaterno;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Apellidomaterno;
		 

		protected string gxTv_SdtSDT_ConsultaDNI_Nombres;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDT_ConsultaDNI", Namespace="UPC_ArquitecturaSistemasOP")]
	public class SdtSDT_ConsultaDNI_RESTInterface : GxGenericCollectionItem<SdtSDT_ConsultaDNI>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ConsultaDNI_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ConsultaDNI_RESTInterface( SdtSDT_ConsultaDNI psdt ) : base(psdt)
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

		[DataMember(Name="apellidoPaterno", Order=20)]
		public  string gxTpr_Apellidopaterno
		{
			get { 
				return sdt.gxTpr_Apellidopaterno;

			}
			set { 
				 sdt.gxTpr_Apellidopaterno = value;
			}
		}

		[DataMember(Name="apellidoMaterno", Order=21)]
		public  string gxTpr_Apellidomaterno
		{
			get { 
				return sdt.gxTpr_Apellidomaterno;

			}
			set { 
				 sdt.gxTpr_Apellidomaterno = value;
			}
		}

		[DataMember(Name="nombres", Order=22)]
		public  string gxTpr_Nombres
		{
			get { 
				return sdt.gxTpr_Nombres;

			}
			set { 
				 sdt.gxTpr_Nombres = value;
			}
		}


		#endregion

		public SdtSDT_ConsultaDNI sdt
		{
			get { 
				return (SdtSDT_ConsultaDNI)Sdt;
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
				sdt = new SdtSDT_ConsultaDNI() ;
			}
		}
	}
	#endregion
}