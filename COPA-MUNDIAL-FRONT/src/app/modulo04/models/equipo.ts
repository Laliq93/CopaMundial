import { Pais } from './pais';
import { I18nEquipo } from './i18n_equipo';

export class Equipo {
    private _pais: Pais;
    private _descripcion: I18nEquipo[];
    private _status: boolean;    // el equipo participa aun o no en la competencia
    private _grupo: string;
    private _habilitado: boolean; // atributo para funcionalidad de que no hayan jugadores sin equipo

    constructor() {
        const descripcionEs = new I18nEquipo();
        descripcionEs.idioma = 'es';
        const descripcionEn = new I18nEquipo();
        descripcionEn.idioma = 'en';
        this._descripcion = new Array<I18nEquipo>();
        this._pais = new Pais();

        this._descripcion.push(descripcionEs, descripcionEn);
    }

    // getters y setters de la clase
    get pais(): Pais {
        return this._pais;
    }

    get descripcion(): I18nEquipo[] {
        return this._descripcion;
    }

    get status(): boolean {
        return this._status;
    }

    get grupo(): string {
        return this._grupo;
    }

    get habilitado(): boolean {
        return this._habilitado;
    }

    set pais(pais: Pais) {
        this._pais = pais;
    }

    set descripcion(descripcion: I18nEquipo[]) {
        this._descripcion = descripcion;
    }

    set status(status: boolean) {
        this._status = status;
    }

    set grupo(grupo: string) {
        this._grupo = grupo;
    }

    set habilitado(habilitado: boolean) {
        this._habilitado = habilitado;
    }
}
