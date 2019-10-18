// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#include "ProjectAutomanGameMode.h"
#include "PlayerCharacter.h"

AProjectAutomanGameMode::AProjectAutomanGameMode()
{
	// Set default pawn class to our character
	DefaultPawnClass = APlayerCharacter::StaticClass();
}
