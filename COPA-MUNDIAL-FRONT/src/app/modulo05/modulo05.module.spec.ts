import { Modulo05Module } from './modulo05.module';

describe('Modulo05Module', () => {
  let modulo05Module: Modulo05Module;

  beforeEach(() => {
    modulo05Module = new Modulo05Module();
  });

  it('should create an instance', () => {
    expect(modulo05Module).toBeTruthy();
  });
});
