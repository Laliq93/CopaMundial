export class I18nEquipo {
    private _id: number;
    private _idioma: string;
    private _mensaje: string;

    // getters y setters de la clase
    get getId(): number {
        return this._id;
    }

    get getIdioma(): string {
        return this._idioma;
    }

    get getMensaje(): string {
        return this._mensaje;
    }

    set setId(id: number) {
        this._id = id;
    }

    set setIdioma(idioma: string) {
        this._idioma = idioma;
    }

    set setMensaje(mensaje: string) {
        this._mensaje = mensaje;
    }
}
