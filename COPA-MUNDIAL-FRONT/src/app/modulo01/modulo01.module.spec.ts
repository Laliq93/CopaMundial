import { Modulo01Module } from './modulo01.module';

describe('Modulo01Module', () => {
  let modulo01Module: Modulo01Module;

  beforeEach(() => {
    modulo01Module = new Modulo01Module();
  });

  it('should create an instance', () => {
    expect(modulo01Module).toBeTruthy();
  });
});
