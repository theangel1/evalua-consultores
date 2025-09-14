import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PhoneFormatPipe } from '../core/pipes/phone-format-pipe';
import { CommonModule } from '@angular/common';
import { Nav } from "../layout/nav/nav";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, PhoneFormatPipe, CommonModule, Nav],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

  private http = inject(HttpClient);
  protected clients = signal<any>([]);
  protected title = "Consulta Clientes"

  ngOnInit(): void {
    this.loadClients()
  }

  loadClients() {

    this.http.get("http://localhost:5005/api/client").subscribe({
      next: response => this.clients.set(response),
      error: error => console.log(error),
      complete: () => console.log("completed")
    })

  }

}
