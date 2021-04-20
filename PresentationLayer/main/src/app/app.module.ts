import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonDetailsComponent } from './person-details/person-details.component';
import { PersonDetailFormComponent } from './person-details/person-detail-form/person-detail-form.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HeroesComponent } from './heroes/heroes.component';
import { PaymentDetailAccountListComponent } from './person-details/payment-detail-account-list/payment-detail-account-list.component';
import { PersonListComponent } from './person-list/person-list.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonDetailsComponent,
    PersonDetailFormComponent,
    HeroesComponent,
    PaymentDetailAccountListComponent,
    PersonListComponent
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
