import { Selecao } from "./selecao.model";

export interface Jogo {
  id?: number;
  selecaoA?: Selecao;
  selecaoB?: Selecao;
  selecaoAId?: number; 
  selecaoBId?: number; 
  placarA?: number; 
  placarB?: number; 
  criadoEm?: string;
}
