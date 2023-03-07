import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TrainerListComponent } from './components/trainers/trainer-list/trainer-list.component';
import { AddTrainerComponent } from './components/trainers/add-trainer/add-trainer.component';
import { EditTrainerComponent } from './components/trainers/edit-trainer/edit-trainer.component';
import { DeleteTrainerComponent } from './components/trainers/delete-trainer/delete-trainer.component';

@NgModule({
  declarations: [
    AppComponent,
    TrainerListComponent,
    AddTrainerComponent,
    EditTrainerComponent,
    DeleteTrainerComponent
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
