import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'signup',
    loadChildren: () => import('./signup/signup.module').then( m => m.SignupPageModule)
  },
  {
    path: 'products',
    loadChildren: () => import('./folder/products/products.module').then( m => m.ProductsPageModule)
  },
  {
    path: 'product-create',
    loadChildren: () => import('./folder/products/product-create/product-create.module').then( m => m.ProductCreatePageModule)
  },
  {
    path: 'clients',
    loadChildren: () => import('./folder/clients/clients.module').then( m => m.ClientsPageModule)
  },
  {
    path: 'client-create',
    loadChildren: () => import('./folder/clients/client-create/client-create.module').then( m => m.ClientCreatePageModule)
  },
  {
    path: 'impuest',
    loadChildren: () => import('./folder/impto/impto.module').then( m => m.ImptoPageModule)
  },
  {
    path: 'impuest-create',
    loadChildren: () => import('./folder/impto/impto-create/impto-create.module').then( m => m.ImptoCreatePageModule)
  },
  {
    path: 'folder/:id',
    loadChildren: () => import('./folder/folder.module').then( m => m.FolderPageModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
