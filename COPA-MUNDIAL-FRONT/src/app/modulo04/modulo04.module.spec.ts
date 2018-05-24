import { Modulo04Module } from './modulo04.module';

describe('Modulo04Module', () => {
  let modulo04Module: Modulo04Module;

  beforeEach(() => {
    modulo04Module = new Modulo04Module();
  });

  it('should create an instance', () => {
    expect(modulo04Module).toBeTruthy();
  });
});
