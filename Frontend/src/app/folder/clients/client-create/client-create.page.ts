import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-client-create',
  templateUrl: './client-create.page.html',
  styleUrls: ['./client-create.page.scss'],
})
export class ClientCreatePage implements OnInit {

  private url: string = 'https://localhost:7085/api/clients/';
  public razonSocial: string = '';
  public nit: string = '';
  public telefono: string = '';
  public direccion: string = '';

  constructor(
    private _http: HttpClient,
    private _alertController: AlertController,
    private _router: Router
  ) {}

  ngOnInit() {}

  async presentAlert(header$: string, message$: string) {
    const alert = await this._alertController.create({
      header: header$,
      message: message$,
      buttons: ['OK'],
    });

    await alert.present();
  }

  setClient() {
    const model = {
      IdCliente: 0,
      Nit: this.nit,
      RazonSocial: this.razonSocial,
      Telefono: this.telefono,
      Direccion: this.direccion
    };
    this._http.post(this.url, model).subscribe((res: any) => {
      if (res) {
        this.presentAlert('Exito', 'El cliente fue guardado correctamente');
        this._router.navigate(['/clients']);
      } else
        this.presentAlert('Error', 'El cliente no se pudo guardar');
    });
  }

}
