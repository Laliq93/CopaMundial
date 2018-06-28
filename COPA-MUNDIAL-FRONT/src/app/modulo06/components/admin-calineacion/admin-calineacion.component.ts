import { Component, OnInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-calineacion',
  templateUrl: './admin-calineacion.component.html',
  styleUrls: ['./admin-calineacion.component.css']
})
export class AdminCalineacionComponent implements OnInit {

  public listmatch: Array<any> = [
    {
      estadio: 'Ekaterinburg Arena',
      ciudad: 'EKATERINBURG',
      fecha: '4 jun. 2018',
      fase: 'Octavos de final',
      equipo1: 'EGIPTO',
      bandera1: '../../../assets/banderas/egy.png',
      hora: '08:00',
      equipo2: 'URUGUAY',
      bandera2: '../../../assets/banderas/uru.png',
    }
  ];

  constructor(private router: Router) { }

  ngOnInit() {
  }

  matchCreate(): void {
    this.router.navigate(['partidos/crearPartido']);
  }

  matchUpdate(): void {
    this.router.navigate(['partidos/modificarPartido']);
  }

  matchList(): void {
    this.router.navigate(['partidos/listaPartidos']);
  }
 
  matchLineup(): void {
    this.router.navigate(['partidos/partidos']);
  }

  public contarTitulares(): number {
    let cantJugTit = 0;
    for ( let i = 0; i < this.listAlineacion1[0].players.length; i++ ) {
      if ( this.listAlineacion1[0].players[i].estado == 'titular' ) {
        cantJugTit++;
      }
    }

    return cantJugTit;
  }

  public agregarJugador1():void
  {
    const cantJugTit = this.contarTitulares();
    if ( cantJugTit == 11) {
      alert('Ya hay 11 jugadores titulares, no se pueden agregar mas jugadores.');
    } else {
      this.listAlineacion1[0].players.push({
        nombre: 'Prueba',
        posicion: 'defensor1',
        numero: '123',
        estado: 'titular'
      });
    }
}

  public agregarJugador2():void
  {
    this.listAlineacion2[0].players.push({
      nombre: 'Prueba',
        posicion: 'arquero',
        numero: '123',
        estado: 'titular'
    });
    console.log(this.listAlineacion1);
    /* alert(this.listAlineacion1[0].players[17].nombre);*/
     
  }

  
  public listAlineacion1: Array<any>=[
    {
      "equipo": "EGIPTO",
      "players": [ {
        "nombre":"NIGMATULLIN",
        "posicion":"arquero",
        "numero": "1",
        "estado":"titular"
        
      },
      {
        "nombre":"KOVTUN",
        "posicion":"defensor1",
        "numero": "2",
        "estado":"titular"
      },
      {
        "nombre":"NIKIFOROV",
        "posicion":"defensor2",
        "numero": "3",
        "estado":"titular"
      },
      {
        "nombre":"SOLOMATIN",
        "posicion":"defensor3",
        "numero": "5",
        "estado":"titular"
      },
      {
        "nombre":"SEMSHOV",
        "posicion":"defensor4",
        "numero": "6",
        "estado":"titular"
      },
      {
        "nombre":"ONOPKO",
        "posicion":"medio campista1",
        "numero": "7",
        "estado":"titular"
  
      },
      {
        "nombre":"KARPIN",
        "posicion":"medio campista2",
        "numero": "8",
        "estado":"titular"
  
      },
      {
        "nombre":"TITOV",
        "posicion":"medio campista3",
        "numero": "9",
        "estado":"titular"
    
      },
      {
        "nombre":"BESCHASTNYKH",
        "posicion":"delantero1",
        "numero": "11",
        "estado":"titular"
     
      },
      {
        "nombre":"PIMENOV",
        "posicion":"delantero2",
        "numero": "19",
        "estado":"titular"
     
      },
      {
        "nombre":"IZMAYLOV",
        "posicion":"delantero3",
        "numero": "20",
        "estado":"titular"
     
      },
      {
        "nombre":"SMERTIN",
        "posicion":"arquero",
        "numero": "19",
        "estado":"suplente"
     
      },
      {
        "nombre":"MOSTOVOY",
        "posicion":"defensor1",
        "numero": "10",
        "estado":"suplente"
     
      },
      {
        "nombre":"CHERCHESOV",
        "posicion":"defensor2",
        "numero": "12",
        "estado":"suplente"
     
      },
      {
        "nombre":"DAEV",
        "posicion":"delantero1",
        "numero": "13",
        "estado":"suplente"
     
      },
      {
        "nombre":"CHIGAYNOV",
        "posicion":"delantero2",
        "numero": "14",
        "estado":"suplente"
     
      },
      {
        "nombre":"ALENICHEV",
        "posicion":"delantero3",
        "numero": "15",
        "estado":"suplente"
     
      }

    ]
    }

  ]

  
  public listAlineacion2: Array<any>=[
    {
      "equipo": "URUGUAY",
      "players": [ {
        "nombre":"F. MUSLERA",
        "posicion":"arquero",
        "numero": "1",
        "estado":"titular"
       
      },
      {
        "nombre":"D. LUGANO",
        "posicion":"defensor1",
        "numero": "2",
        "estado":"titular"
      
      },
      {
        "nombre":"D. GODIN",
        "posicion":"defensor2",
        "numero": "3",
        "estado":"titular"
       
      },
      {
        "nombre":"W. GARGANO",
        "posicion":"defensor3",
        "numero": "5",
        "estado":"titular"
        
      },
      {
        "nombre":"C. RODRIGUEZ",
        "posicion":"defensor4",
        "numero": "7",
        "estado":"titular"
      },
      {
        "nombre":"D. FORLAN",
        "posicion":"medio campista1",
        "numero": "10",
        "estado":"titular"
      },
      {
        "nombre":"C. STUANI",
        "posicion":"medio campista2",
        "numero": "11",
        "estado":"titular"
      },
      {
        "nombre":"M. PEREIRA",
        "posicion":"medio campista3",
        "numero": "16",
        "estado":"titular"
      },
      {
        "nombre":"E. AREVALO RIOS",
        "posicion":"delantero1",
        "numero": "17",
        "estado":"titular"
      },
      {
        "nombre":"E. CAVANI",
        "posicion":"delantero2",
        "numero": "21",
        "estado":"titular"
      },
      {
        "nombre":"M. CACERES",
        "posicion":"delantero3",
        "numero": "22",
        "estado":"titular"
      },
      {
        "nombre":"R. MUÑOZ",
        "posicion":"arquero",
        "numero": "12",
        "estado":"suplente"
      }
      ,
      {
        "nombre":"M. SILVA",
        "posicion":"arquero",
        "numero": "23",
        "estado":"suplente"
      }
      ,
      {
        "nombre":"J. FUCILE",
        "posicion":"arquero",
        "numero": "4",
        "estado":"suplente"
      },
      {
        "nombre":"A. PEREIRA",
        "posicion":"medio campista1",
        "numero": "6",
        "estado":"suplente"
      },
      {
        "nombre":"A. HERNANDEZ",
        "posicion":"medio campista1",
        "numero":"8",
        "estado":"suplente"
      },
      {
        "nombre":"L. SUAREZ",
        "posicion":"delantero2",
        "numero": "9",
        "estado":"suplente"
      }
    ]
    }

  ]


}
