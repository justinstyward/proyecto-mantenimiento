import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  public appPages = [
    { title: 'Facturas', url: '/folder/Facturas', icon: 'receipt' },
    // { title: 'Crear Factura', url: '/folder/Outbox', icon: 'add' },
    { title: 'Productos', url: '/products', icon: 'grid' },
    // { title: 'Crear Productos', url: '/folder/products', icon: 'add' },
    { title: 'Clientes', url: '/clients', icon: 'happy' },
    { title: 'Impuestos', url: '/impuest', icon: 'cash' },
    { title: 'Cerrar Sesión', url: '/login', icon: 'log-out' },
  ];
  constructor() {}
}
