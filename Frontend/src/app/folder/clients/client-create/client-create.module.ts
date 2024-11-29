import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ClientCreatePageRoutingModule } from './client-create-routing.module';

import { ClientCreatePage } from './client-create.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ClientCreatePageRoutingModule
  ],
  declarations: [ClientCreatePage]
})
export class ClientCreatePageModule {}
