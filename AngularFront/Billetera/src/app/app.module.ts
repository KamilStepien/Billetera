import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {MatInputModule} from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import {MatButtonToggleModule} from '@angular/material/button-toggle';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import { UserService } from './shared/user.service';
import { UserRegisterComponent } from './user-register/user-register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserAuthenticateComponent } from './user-authenticate/user-authenticate.component';
import { StartPageComponent } from './start-page/start-page.component';
import { DataboardComponent } from './main-continer/databoard/databoard.component';
import { TransactionsComponent } from './main-continer/transactions/transactions.component';
import { TransactionAddComponent } from './main-continer/transactions/transaction-add/transaction-add.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MenuComponent } from './main-continer/menu/menu.component';
import { TransactionsListComponent } from './main-continer/transactions/transactions-list/transactions-list.component';
import { TransactionsListElementComponent } from './main-continer/transactions/transactions-list-element/transactions-list-element.component';
@NgModule({
  declarations: [
    AppComponent,
    UserRegisterComponent,
    UserAuthenticateComponent,
    StartPageComponent,
    DataboardComponent,
    TransactionsComponent,
    TransactionAddComponent,
    MenuComponent,
    TransactionsListComponent,
    TransactionsListElementComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCardModule,
    FlexLayoutModule,
    MatButtonToggleModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
