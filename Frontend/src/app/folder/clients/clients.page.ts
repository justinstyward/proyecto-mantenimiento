import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

export interface ClientsTypes {
  idCliente: number;
  nit: string;
  razonSocial: string;
  telefono: string;
  direccion: string;
}

@Component({
  selector: 'app-clients',
  templateUrl: './clients.page.html',
  styleUrls: ['./clients.page.scss'],
})
export class ClientsPage implements OnInit {

  private url: string = 'https://localhost:7085/api/clients/';
  public clients: ClientsTypes[] = [];

  constructor(private _http: HttpClient) {}

  ngOnInit() {
    this.getClients();
  }

  getClients() {
    this.clients = [];
    this._http.get(this.url).subscribe((res: any) => {
      res.forEach((element: any) => {
        this.clients.push({
          idCliente: element.idCliente,
          nit: element.nit,
          razonSocial: element.razonSocial,
          telefono: element.telefono,
          direccion: element.direccion,
        });
      });
    });
  }

}
