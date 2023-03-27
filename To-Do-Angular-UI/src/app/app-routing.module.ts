import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { LogoutComponent } from './components/auth/logout/logout.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { HomePageComponent } from './components/home/home-page/home-page.component';
import { MissionPageComponent } from './components/missions/mission-page/mission-page.component';
import {UserProfileComponent} from './components/users/add-user/add-user.component'
import { ProfileComponent } from './components/users/profile/profile.component';

const routes: Routes = [
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'create-profile',
    component: UserProfileComponent
  },
  {
    path: 'missions',
    component: MissionPageComponent

  },
  {
    path: 'logout',
    component: LogoutComponent
  },
  {
    path: 'home',
    component: HomePageComponent
  },
  {
    path: 'profile',
    component: ProfileComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
