import { Component, OnInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router'; 

@Component({
  selector: 'app-match-detail',
  templateUrl: './match-detail.component.html',
  styleUrls: ['./match-detail.component.css']
})
export class MatchDetailComponent implements OnInit {

  constructor(private router: Router){}


  ngOnInit() {
  }

  faseGrupos(): void {
		this.router.navigate(['home/match']);
  }	

  faseEliminatorias(): void {
		this.router.navigate(['home/match/Eliminatorias']);
  }	

  public listmatch: Array<any>= [
    {
      "estadio": "Ekaterinburg Arena",
      "ciudad": "EKATERINBURG",
      "fecha":"14 jun. 2018",
      "fase": "Octavos de final",
      "equipo1": "EGIPTO",
      "bandera1": "../../../assets/banderas/egy.png",
      "hora": "08:00",
      "puntaje": "1 - 0 ",
      "equipo2": "URUGUAY",
      "bandera2": "../../../assets/banderas/uru.png",
    }
  ]

  public listAlineacion1: Array<any>=[
    {
      "equipo": "EGIPTO",
      "players": [ {
        "nombre":"NIGMATULLIN",
        "posicion":"titular",
        "numero": "1"
        
      },
      {
        "nombre":"KOVTUN",
        "posicion":"titular",
        "numero": "2"
       
      },
      {
        "nombre":"NIKIFOROV",
        "posicion":"titular",
        "numero": "3",
      },
      {
        "nombre":"SOLOMATIN",
        "posicion":"titular",
        "numero": "5",
      },
      {
        "nombre":"SEMSHOV",
        "posicion":"titular",
        "numero": "6",
      },
      {
        "nombre":"ONOPKO",
        "posicion":"titular",
        "numero": "7",
  
      },
      {
        "nombre":"KARPIN",
        "posicion":"titular",
        "numero": "8",
  
      },
      {
        "nombre":"TITOV",
        "posicion":"titular",
        "numero": "9",
    
      },
      {
        "nombre":"BESCHASTNYKH",
        "posicion":"titular",
        "numero": "11",
     
      },
      {
        "nombre":"PIMENOV",
        "posicion":"titular",
        "numero": "19",
     
      },
      {
        "nombre":"IZMAYLOV",
        "posicion":"titular",
        "numero": "20",
     
      },
      {
        "nombre":"SMERTIN",
        "posicion":"suplente",
        "numero": "19",
     
      },
      {
        "nombre":"MOSTOVOY",
        "posicion":"suplente",
        "numero": "10",
     
      },
      {
        "nombre":"CHERCHESOV",
        "posicion":"suplente",
        "numero": "12",
     
      },
      {
        "nombre":"DAEV",
        "posicion":"suplente",
        "numero": "13",
     
      },
      {
        "nombre":"CHIGAYNOV",
        "posicion":"suplente",
        "numero": "14",
     
      },
      {
        "nombre":"ALENICHEV",
        "posicion":"suplente",
        "numero": "15",
     
      }

    ]
    }

  ]
  public listAlineacion2: Array<any>=[
    {
      "equipo": "URUGUAY",
      "players": [ {
        "nombre":"F. MUSLERA",
        "posicion":"titular",
        "numero": "1",
       
      },
      {
        "nombre":"D. LUGANO",
        "posicion":"titular",
        "numero": "2",
      
      },
      {
        "nombre":"D. GODIN",
        "posicion":"titular",
        "numero": "3",
       
      },
      {
        "nombre":"W. GARGANO",
        "posicion":"titular",
        "numero": "5",
        
      },
      {
        "nombre":"C. RODRIGUEZ",
        "posicion":"titular",
        "numero": "7",
        
      },
      {
        "nombre":"D. FORLAN",
        "posicion":"titular",
        "numero": "10",
       
      },
      {
        "nombre":"C. STUANI",
        "posicion":"titular",
        "numero": "11",
       
      },
      {
        "nombre":"M. PEREIRA",
        "posicion":"titular",
        "numero": "16",
       
      },
      {
        "nombre":"E. AREVALO RIOS",
        "posicion":"titular",
        "numero": "17",
       
      },
      {
        "nombre":"E. CAVANI",
        "posicion":"titular",
        "numero": "21",
       
      },
      {
        "nombre":"M. CACERES",
        "posicion":"titular",
        "numero": "22",

      },
      {
        "nombre":"R. MUÑOZ",
        "posicion":"suplente",
        "numero": "12",
       
      }
      ,
      {
        "nombre":"M. SILVA",
        "posicion":"suplente",
        "numero": "23",
       
      }
      ,
      {
        "nombre":"J. FUCILE",
        "posicion":"suplente",
        "numero": "4",
       
      },
      {
        "nombre":"A. PEREIRA",
        "posicion":"suplente",
        "numero": "6",
       
      },
      {
        "nombre":"A. HERNANDEZ",
        "posicion":"suplente",
        "numero": "8",
       
      },
      {
        "nombre":"L. SUAREZ",
        "posicion":"suplente",
        "numero": "9",
       
      }
    ]
    }

  ]


}
