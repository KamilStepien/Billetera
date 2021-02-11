import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CategoriesAddComponent } from './main-continer/categories/categories-add/categories-add.component';
import { CategoriesComponent } from './main-continer/categories/categories.component';
import { DataboardComponent } from './main-continer/databoard/databoard.component';
import { JarsAddEditComponent } from './main-continer/jars/jars-add-edit/jars-add-edit.component';
import { JarsComponent } from './main-continer/jars/jars.component';
import { ShoppingListComponent } from './main-continer/shopping-list/shopping-list.component';
import { TransactionAddEditComponent } from './main-continer/transactions/transaction-add-edit/transaction-add-edit.component';

import { TransactionsComponent } from './main-continer/transactions/transactions.component';
import { AuthGuardService } from './shared/auth-guard-service.service';
import { StartPageComponent } from './start-page/start-page.component';
import { UserAuthenticateComponent } from './user-authenticate/user-authenticate.component';
import { UserRegisterComponent } from './user-register/user-register.component';

const routes: Routes = [
  { path: '', component: StartPageComponent },
  { path: 'authenticate', component: UserAuthenticateComponent },
  { path: 'register', component: UserRegisterComponent},
  { path: 'transaction', component: TransactionsComponent, canActivate : [AuthGuardService] },
  { path: 'jar', component: JarsComponent, canActivate : [AuthGuardService]},
  { path: 'transaction/add', component: TransactionAddEditComponent, canActivate : [AuthGuardService]},
  { path: 'transaction/edit/:id', component: TransactionAddEditComponent, canActivate : [AuthGuardService]},
  { path: 'transaction/categorie', component: CategoriesComponent, canActivate : [AuthGuardService]},
  { path: 'transaction/categorie/add', component: CategoriesAddComponent, canActivate : [AuthGuardService]},
  { path: 'dashboard', component: DataboardComponent, canActivate : [AuthGuardService]},
  { path: 'shoppingList', component: ShoppingListComponent, canActivate : [AuthGuardService]},
  { path: 'jar/add', component: JarsAddEditComponent, canActivate : [AuthGuardService]},
  { path: 'jar/edit/:id', component: JarsAddEditComponent, canActivate : [AuthGuardService]}


]

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
