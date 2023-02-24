import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { SampleCompComponent } from './demo-module/sample-comp/sample-comp.component';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatButtonModule} from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatChipsModule} from '@angular/material/chips';


@NgModule({
  declarations: [
    AppComponent,
    SampleCompComponent
   
  ],
  imports: [
    BrowserModule,
    FormsModule,
    NgbModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatDatepickerModule,
    MatChipsModule
 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

