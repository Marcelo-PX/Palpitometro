import { Component, OnInit } from "@angular/core";
import { Selecao } from "src/app/models/selecao.model";
import {HttpClient} from '@angular/common/http'
import { ActivatedRoute, Router } from "@angular/router";
import { Jogo } from "src/app/models/jogo.model";
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: "app-cadastrar-jogo",
  templateUrl: "./cadastrar-jogo.component.html",
  styleUrls: ["./cadastrar-jogo.component.css"],
})
export class CadastrarJogoComponent implements OnInit {
  selecaoAId!: number;
  selecaoBId!: number;  
  selecoes!: Selecao[]; 

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.http.get<Selecao[]>
      ("https://localhost:5001/api/selecao/listar")
      .subscribe({
        next: (selecoes) => {
          this.selecoes = selecoes;
        }
      });
  }

  cadastrar(): void {
    let jogo: Jogo = { 
      selecaoAId: this.selecaoAId, 
      selecaoBId: this.selecaoBId, 
    }; 

    this.http.post<Jogo>("https://localhost:5001/api/jogo/cadastrar", jogo)
    .subscribe({
      next: (jogo) =>{
        console.log("Jogo adicionado com sucesso");
      },
    });
    console.log(jogo);
  }

  openSnackBar(message: string, action: string){
    let snackBarRef = this.snackBar.open(message,action);
  }
}
