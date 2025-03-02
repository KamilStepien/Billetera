import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {MatInputModule} from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatFormFieldModule} from '@angular/material/form-field';

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
import { FlexLayoutModule } from '@angular/flex-layout';
import { MenuComponent } from './main-continer/menu/menu.component';
import { TransactionsListComponent } from './main-continer/transactions/transactions-list/transactions-list.component';
import { TransactionsListElementComponent } from './main-continer/transactions/transactions-list-element/transactions-list-element.component';
import {MatDialogModule} from '@angular/material/dialog';
import { JarsComponent } from './main-continer/jars/jars.component';
import { TransactionService } from './shared/transaction.service';
import { CategorieService } from './shared/categorie.service';
import { CategoriesComponent } from './main-continer/categories/categories.component';
import { CategorieListElementComponent } from './main-continer/categories/categorie-list-element/categorie-list-element.component';
import { CategorieListComponent } from './main-continer/categories/categorie-list/categorie-list.component';
import { CategoriesAddComponent } from './main-continer/categories/categories-add/categories-add.component';
import { TransactionAddEditComponent } from './main-continer/transactions/transaction-add-edit/transaction-add-edit.component';
import * as echarts from 'echarts';
import { NgxEchartsModule } from 'ngx-echarts';
import {NgPipesModule} from 'ngx-pipes';
import { ShoppingListComponent } from './main-continer/shopping-list/shopping-list.component';
import { ShoppingElementComponent } from './main-continer/shopping-list/shopping-element/shopping-element.component';
import { ShoppingElementAddComponent } from './main-continer/shopping-list/shopping-element-add/shopping-element-add.component';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { ShoppingListService } from './shared/shopping-list.service';
import { JarsListComponent } from './main-continer/jars/jars-list/jars-list.component';
import { JarListElementComponent } from './main-continer/jars/jar-list-element/jar-list-element.component';
import { AddMoneyToJarComponent } from './main-continer/jars/add-money-to-jar/add-money-to-jar.component';
import { JarsAddEditComponent } from './main-continer/jars/jars-add-edit/jars-add-edit.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { NotificationListComponent } from './main-continer/notifications/notification-list/notification-list.component';
import { NotificationListElementComponent } from './main-continer/notifications/notification-list-element/notification-list-element.component';
import { BilansComponent } from './main-continer/databoard/bilans/bilans.component';
import { JarService } from './shared/jar.service';
import { AuthGuardService } from './shared/auth-guard-service.service';
import { TransactionSearchComponent } from './main-continer/transactions/transaction-search/transaction-search.component';
import { UserComponent } from './main-continer/user/user.component';
import { UserEditComponent } from './main-continer/user/user-edit/user-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    UserRegisterComponent,
    UserAuthenticateComponent,
    StartPageComponent,
    DataboardComponent,
    TransactionsComponent,
    MenuComponent,
    TransactionsListComponent,
    TransactionsListElementComponent,
    JarsComponent,
    CategoriesComponent,
    CategorieListElementComponent,
    CategorieListComponent,
    CategoriesAddComponent,
    TransactionAddEditComponent,
    ShoppingListComponent,
    ShoppingElementComponent,
    ShoppingElementAddComponent,
    JarsListComponent,
    JarListElementComponent,
    AddMoneyToJarComponent,
    JarsAddEditComponent,
    NotificationListComponent,
    NotificationListElementComponent,
    BilansComponent,
    TransactionSearchComponent,
    UserComponent,
    UserEditComponent,
    
  ],
  imports: [
    BrowserModule,
    NgxEchartsModule.forRoot({
      echarts
    }),
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCardModule,
    FlexLayoutModule,
    MatButtonToggleModule,
    MatFormFieldModule,
    MatDialogModule,
    NgPipesModule,
    DragDropModule,
    MatProgressBarModule,
    
  
  ],
  providers: [UserService,TransactionService, CategorieService, ShoppingListService,JarService,AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
