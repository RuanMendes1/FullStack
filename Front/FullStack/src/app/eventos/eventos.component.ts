import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {


  public evento: any = [];
  public eventoFiltrado: any = []

  larguraImg: number = 60;
  margemImg: number = 2;
  mostrarImagem: boolean = true
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value
    this.eventoFiltrado = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.evento
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.evento.filter(
     (evento: any)  => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient ) { }

  ngOnInit(): void {
    this.getEventos()
  }

  public getEventos(): void {
    this.http.get('https://localhost:7217/api/eventos').subscribe(
      response => {
        this.evento = response,
        this.eventoFiltrado = this.evento
      },
      error => console.log(error),
    );
  }

  showImage(){
    this.mostrarImagem = !this.mostrarImagem
  }
}
