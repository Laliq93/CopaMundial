export class I18nEquipo {
    private _id: number;
    private _idioma: string;
    private _mensaje: string;

    // getters y setters de la clase
    get id(): number {
        return this._id;
    }

    get idioma(): string {
        return this._idioma;
    }

    get mensaje(): string {
        return this._mensaje;
    }

    set id(id: number) {
        this._id = id;
    }

    set idioma(idioma: string) {
        this._idioma = idioma;
    }

    set mensaje(mensaje: string) {
        this._mensaje = mensaje;
    }
}
