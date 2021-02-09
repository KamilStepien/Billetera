import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CategoriesAddComponent } from './main-continer/categories/categories-add/categories-add.component';
import { CategoriesComponent } from './main-continer/categories/categories.component';
import { DataboardComponent } from './main-continer/databoard/databoard.component';
import { JarsComponent } from './main-continer/jars/jars.component';
import { TransactionAddEditComponent } from './main-continer/transactions/transaction-add-edit/transaction-add-edit.component';

import { TransactionsComponent } from './main-continer/transactions/transactions.component';
import { StartPageComponent } from './start-page/start-page.component';
import { UserAuthenticateComponent } from './user-authenticate/user-authenticate.component';
import { UserRegisterComponent } from './user-register/user-register.component';

const routes: Routes = [
  { path: '', component: StartPageComponent },
  { path: 'authenticate', component: UserAuthenticateComponent },
  { path: 'register', component: UserRegisterComponent},
  { path: 'transaction', component: TransactionsComponent},
  { path: 'jar', component: JarsComponent},
  { path: 'transaction/add', component: TransactionAddEditComponent},
  { path: 'transaction/edit/:id', component: TransactionAddEditComponent},
  { path: 'transaction/categorie', component: CategoriesComponent},
  { path: 'transaction/categorie/add', component: CategoriesAddComponent},
  { path: 'dashboard', component: DataboardComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
