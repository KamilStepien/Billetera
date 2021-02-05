import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { JarsComponent } from './main-continer/jars/jars.component';
import { TransactionAddComponent } from './main-continer/transactions/transaction-add/transaction-add.component';
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
  { path: 'transaction/add', component: TransactionAddComponent},
]

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
