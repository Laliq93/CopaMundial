using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{

	public class equipo
	{
		public equipo(String nombre, int valor)
		{
			this.nombre = nombre;
			this.valor = valor;

		}


		public String nombre;
		public int valor;
	}


	public class EstEquipo
	{
		public EstEquipo()
		{

		}
		public int rendimiento;
		public int posesion;
		public int tiros;
		public int esquina;
		public int tarjetasA;
		public int tarjetasR;
		public int offsides;
		public int faltasR;
		public int faltasC;
		public int goles;
		public int tirosfuera;
	}

	public class EstJugador
	{
		public EstJugador(String nombre, int valor, int minuto)
		{
			this.nombre = nombre;
			this.valor = valor;
			this.minuto = minuto;

		}
		public String nombre;
		public int valor;
		public int minuto;

	}

	public class EstJugGen
	{
		public EstJugGen(int goles, int asistencias, int tiempojugado,
			int tiros, int tarjetasR, int tarjetasA,
			int faltasR, int faltasC, int golesrec,
			int penaltisA, int portimb)
		{
			this.goles = goles;
			this.asistencias = asistencias;
			this.tiempojugado = tiempojugado;
			this.tiros = tiros;
			this.tarjetasR = tarjetasR;
			this.tarjetasA = tarjetasA;
			this.faltasR = faltasR;
			this.faltasC = faltasC;
			this.golesrec = golesrec;
			this.penaltisA = penaltisA;
			this.portimb = portimb;
		}
		public EstJugGen()
		{

		}

		public int goles;
		public int asistencias;
		public int tiempojugado;
		public int tiros;
		public int tarjetasR;
		public int tarjetasA;
		public int faltasR;
		public int faltasC;
		public int golesrec;
		public int penaltisA;
		public int portimb;
		public int offsides;


	}

	public class EstPartido
	{

	}


	public class Prediccion
	{

		public Prediccion()
		{
		}

		public Prediccion(String nombre, int valor)
		{
			this.nombre = nombre;
			this.valor = valor;
		}

		public String nombre;
		public int valor;

	}
}
