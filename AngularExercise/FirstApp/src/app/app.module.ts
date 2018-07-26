import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { FirstComponentComponent } from './first-component/first-component.component';
import { ChatScreenComponent } from './chat-screen/chat-screen.component';

@NgModule({
  declarations: [
    AppComponent,
    FirstComponentComponent,
    ChatScreenComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
