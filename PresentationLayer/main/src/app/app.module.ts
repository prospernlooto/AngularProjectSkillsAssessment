import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HeroesComponent } from './heroes/heroes.component';
import { PersonFormComponent } from './pages/person-form/person-form.component';
import { PersonListComponent } from './person-list/person-list.component';
import { AccountsListComponent } from './pages/accounts-list/accounts-list.component';
import { AccountsFormComponent } from './pages/accounts-form/accounts-form.component';
import { TransactionsFormComponent } from './pages/transactions-form/transactions-form.component';
import { TransactionsListComponent } from './pages/transactions-list/transactions-list.component';
import { WelcomeViewComponent } from './pages/welcome-view/welcome-view.component';
import { AboutMeViewComponent } from './pages/about-me-view/about-me-view.component';
import { ContactMeViewComponent } from './pages/contact-me-view/contact-me-view.component';

@NgModule({
  declarations: [
    AppComponent,
    HeroesComponent,
    PersonListComponent,
    PersonFormComponent,
    AccountsListComponent,
    AccountsFormComponent,
    TransactionsFormComponent,
    TransactionsListComponent,
    WelcomeViewComponent,
    AboutMeViewComponent,
    ContactMeViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
