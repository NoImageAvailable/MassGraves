#!/bin/sh

TARGET_DIR="/mnt/c/Program Files (x86)/Steam/steamapps/common/RimWorld/Mods/Mass Graves"
rm -rf "${TARGET_DIR}"
mkdir "${TARGET_DIR}"
cp -r About "${TARGET_DIR}"
cp -r Assemblies "${TARGET_DIR}"
cp -r Defs "${TARGET_DIR}"
cp -r Languages "${TARGET_DIR}"
cp -r Patches "${TARGET_DIR}"
cp -r Textures "${TARGET_DIR}"
