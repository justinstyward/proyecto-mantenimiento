import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClientCreatePage } from './client-create.page';

const routes: Routes = [
  {
    path: '',
    component: ClientCreatePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientCreatePageRoutingModule {}
