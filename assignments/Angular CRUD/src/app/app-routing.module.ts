import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddTrainerComponent } from './components/trainers/add-trainer/add-trainer.component';
import { DeleteTrainerComponent } from './components/trainers/delete-trainer/delete-trainer.component';
import { EditTrainerComponent } from './components/trainers/edit-trainer/edit-trainer.component';
import { TrainerListComponent } from './components/trainers/trainer-list/trainer-list.component';

const routes: Routes = [
  
  {path:'trainers',component:TrainerListComponent},
  {path:'trainers/add',component:AddTrainerComponent},
  {path:'trainers/edit/:email',component:EditTrainerComponent},
  {path:'trainers/delete/:email',component:DeleteTrainerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
