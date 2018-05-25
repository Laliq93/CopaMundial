import { Modulo03Module } from './modulo03.module';

describe('Modulo03Module', () => {
  let modulo03Module: Modulo03Module;

  beforeEach(() => {
    modulo03Module = new Modulo03Module();
  });

  it('should create an instance', () => {
    expect(modulo03Module).toBeTruthy();
  });
});
